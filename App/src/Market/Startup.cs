using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Market.Services;
using Market.Core;
using Market.Core.Database;
using Market.Core.Identity;
using Market.Core.Products;
using Market.Core.Users;
using Microsoft.AspNet.Authentication.Cookies;
using Market.Infrastructure.Localization;
using Market.Resources;
using Microsoft.Extensions.Localization;
using Swashbuckle.SwaggerGen;

namespace Market
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            
            //add asp.net identity
            services.AddIdentity<User, Role>(o =>
                {
                    o.Password.RequireDigit = false;
                    o.Password.RequireNonLetterOrDigit = false;
                    o.Password.RequiredLength = 6;
                    o.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<DataContext, int>()
                .AddDefaultTokenProviders();

            //localize routes
            var localizedRoutes = GetLocalizedURLs();
            services.AddMvc(o => o.AddLocalizedRoutes(localizedRoutes))
                .AddViewLocalization(options => options.ResourcesPath = "Resources")
                .AddDataAnnotationsLocalization();

            //services.AddSwaggerGen();

            //var path = Configuration["DNX_APPBASE"];
            //path = path.Remove(path.LastIndexOf(@"\"));
            //path = path.Remove(path.LastIndexOf(@"\"));
            //var pathToDoc = string.Format(@"{0}\artifacts\bin\Market\Debug\dnx451\Market.xml", path);
            //services.ConfigureSwaggerDocument(options =>
            //{
            //    options.SingleApiVersion(new Info
            //    {
            //        Version = "v1",
            //        Title = "Market API",
            //        Description = "A simple api to search products",
            //        TermsOfService = "None"
            //    });
            //    options.OperationFilter(new Swashbuckle.SwaggerGen.XmlComments.ApplyXmlActionComments(pathToDoc));
            //});

            //services.ConfigureSwaggerSchema(options =>
            //{
            //    options.DescribeAllEnumsAsStrings = true;
            //    options.ModelFilter(new Swashbuckle.SwaggerGen.XmlComments.ApplyXmlTypeComments(pathToDoc));
            //});
            

            // Add application services.
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<DataContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseStaticFiles();

            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseSwaggerGen();
            //app.UseSwaggerUi();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

        /// <summary>
        /// Get localized URLs for actions
        /// </summary>
        /// <returns>Localized URLs</returns>
        private Dictionary<string, LocalizedRouteInformation[]> GetLocalizedURLs()
        {
            return new Dictionary<string, LocalizedRouteInformation[]>
            {
                {
                "login", new[]
                    {
                        new LocalizedRouteInformation("sr", "prijava"),
                    }
                },
                //{
                //    "orderById", new[]
                //    {
                //        new LocalizedRouteInformation("sr", "porudzbina/{id:int}"),
                //    }
                //}
            };
        }

        /// <summary>
        /// Add application services
        /// </summary>
        /// <param name="services"></param>
        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            //services.AddScoped<IProductService, ProductService>();//todo: auto bind
            services.AddSingleton<IStringLocalizerFactory, ResxStringLocalizerFactory>();
        }
    }
}
