using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ApplicationModels;
using Microsoft.AspNet.Mvc.Filters;

namespace Market.Infrastructure.Localization
{
    public class LocalizedRouteAttribute : RouteAttribute
    {
        public LocalizedRouteAttribute(string template) : base(template)
        {
            Culture = "en-US";
        }

        public string Culture { get; set; }
    }

public class LocalizedRouteInformation
{
    public string Culture { get; }
    public string Template { get; }
 
    public LocalizedRouteInformation(string culture, string template)
    {
        Culture = culture;
        Template = template;
    }
}


public class LocalizedRouteConvention : IApplicationModelConvention
{
    private readonly Dictionary<string, LocalizedRouteInformation[]> _localizedRoutes;

    public LocalizedRouteConvention(Dictionary<string, LocalizedRouteInformation[]> localizedRoutes)
    {
        _localizedRoutes = localizedRoutes;
    }

    public IEnumerable<AttributeRouteModel> GetLocalizedVersionsForARoute(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) yield break;

        LocalizedRouteInformation[] routeSpecificLocalizedRoutes;
        if (_localizedRoutes.TryGetValue(name, out routeSpecificLocalizedRoutes))
        {
            foreach (var entry in routeSpecificLocalizedRoutes)
            {
                yield return
                    new AttributeRouteModel(new LocalizedRouteAttribute(entry.Template)
                    {
                        Name = name + entry.Culture,
                        Culture = entry.Culture
                    });
            }
        }
    }

    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        { 
            var newActions = new List<ActionModel>();
            foreach (var action in controller.Actions)
            {
                var localizedRouteAttributes = action.Attributes.OfType<LocalizedRouteAttribute>().ToArray();
                if (localizedRouteAttributes.Any())
                {
                    foreach (var localizedRouteAttribute in localizedRouteAttributes)
                    {
                        var localizedVersions = GetLocalizedVersionsForARoute(localizedRouteAttribute.Name);

                        foreach (var localizedVersion in localizedVersions)
                        {
                            var newAction = new ActionModel(action)
                            {
                                AttributeRouteModel = localizedVersion,
                            };
                            newAction.Properties["culture"] = new CultureInfo(((LocalizedRouteAttribute) localizedVersion.Attribute).Culture ?? "en-US");
                            newAction.Filters.Add(new LocalizedRouteFilter());
                            newActions.Add(newAction);
                        }
                    }
                }
            }

            foreach (var newAction in newActions)
            {
                controller.Actions.Add(newAction);
            }
        }
    }
}

public class LocalizedRouteFilter : IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        if (context.ActionDescriptor.Properties.ContainsKey("culture"))
        {
            var culture = context.ActionDescriptor.Properties["culture"] as CultureInfo;
            if (culture != null)
            {
               #if DNX451
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
               #else
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
               #endif
            }
        }
    }
 
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}

public static class RouteLocalizationExtensions
{
    public static void AddLocalizedRoutes(this MvcOptions options, Dictionary<string, LocalizedRouteInformation[]> localizedRoutes)
    {
        options.Conventions.Insert(0, new LocalizedRouteConvention(localizedRoutes));
    }
}
}
