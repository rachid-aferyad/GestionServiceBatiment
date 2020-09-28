using GestionServiceBatiment.ASP.Controllers;
using GestionServiceBatiment.ASP.DependencyInjection;
using GestionServiceBatiment.ASP.Infrastructures;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Infrastructures.Services;
using GestionServiceBatiment.ASP.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tools.Mappers;

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

            Services.AddTransient<ICategoryService, CategoryService>();
            Services.AddTransient<ICommentService, CommentService>();
            Services.AddTransient<ICompanyService, CompanyService>();
            Services.AddTransient<IModificationService, ModificationService>();
            Services.AddTransient<IRejectionService, RejectionService>();
            Services.AddTransient<IRequestService, RequestService>();
            Services.AddTransient<IServiceService, ServiceService>();
            Services.AddTransient<IUserService, UserService>();

            Services.AddTransient(typeof(SharedController));
            Services.AddTransient(typeof(HomeController));
            Services.AddTransient(typeof(CategoryController));
            Services.AddTransient(typeof(CommentController));
            Services.AddTransient(typeof(CompanyController));
            Services.AddTransient(typeof(ModificationController));
            Services.AddTransient(typeof(RejectionController));
            Services.AddTransient(typeof(RequestController));
            Services.AddTransient(typeof(ServiceController));
            Services.AddTransient(typeof(UserController));


            // Add mappers
           Services.AddSingleton<IMappersService, MapperASP>();


            ServiceProvider = Services.BuildServiceProvider();

            var defaultResolver = new DefaultDependencyResolver(ServiceProvider);
            DependencyResolver.SetResolver(defaultResolver);
        }
    }
}
