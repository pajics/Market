using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Microsoft.Extensions.Localization;

namespace Market.Resources
{
    public class ResxStringLocalizer : IStringLocalizer
    {
        public ResxStringLocalizer()
        {
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            //SharedResource.Culture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return new ResxStringLocalizer();
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
        {
            return new List<LocalizedString>();
            //var resourceSet = SharedResource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            //foreach (DictionaryEntry entry in resourceSet)
            //{
            //    yield return new LocalizedString((string)entry.Key, (string)entry.Value);
            //}
        }

        private string GetString(string name)
        {
            return SharedResource.ResourceManager.GetString(name);
        }
    }


    public class ResxStringLocalizer<T> : IStringLocalizer<T>
    {
        public ResxStringLocalizer()
        {
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            //SharedResource.Culture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return new ResxStringLocalizer();
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
        {
            return new List<LocalizedString>();
            //ResourceSet resourceSet = SharedResource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            //foreach (DictionaryEntry entry in resourceSet)
            //{
            //    yield return new LocalizedString((string)entry.Key, (string)entry.Value);
            //}
        }

        private string GetString(string name)
        {
            return SharedResource.ResourceManager.GetString(name);
        }
    }

}