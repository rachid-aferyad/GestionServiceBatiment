using GestionServiceBatiment.ASP.Controllers;
using GestionServiceBatiment.ASP.DependencyInjection;
using GestionServiceBatiment.ASP.Infrastructures;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GestionServiceBatiment.ASP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IServiceProvider ServiceProvider { get; set; }
        private ServiceCollection Services { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Services = new ServiceCollection();
            //Services.AddTransient<IDisposable, HttpClient>();
            Services.AddTransient<ICategoryService, CategoryService>();
            Services.AddTransient(typeof(CategoryController));


            ServiceProvider = Services.BuildServiceProvider();

            var defaultResolver = new DefaultDependencyResolver(ServiceProvider);
            DependencyResolver.SetResolver(defaultResolver);
        }
    }
}
