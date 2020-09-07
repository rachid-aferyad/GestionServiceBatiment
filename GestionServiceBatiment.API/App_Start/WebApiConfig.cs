using GestionServiceBatiment.API.Controllers;
using GestionServiceBatiment.BLL.Services.Implementations;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Repositories;
using GestionServiceBatiment.DAL.Repositories.Implementations;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace GestionServiceBatiment.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            var services = new ServiceCollection();
            InitializeServices(services);
            var provider = services.BuildServiceProvider();

            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceProviderControllerActivator(provider));

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void InitializeServices(IServiceCollection services)
        {
            // Add services
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IModificationRepository, ModificationRepository>();
            services.AddTransient<IRejectionRepository, RejectionRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IModificationService, ModificationService>();
            services.AddTransient<IRejectionService, RejectionService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IUserService, UserService>();

            // Add controllers
            services.AddScoped<CategoryController>(sp => new CategoryController(sp.GetRequiredService<ICategoryService>()));
            services.AddScoped<UserController>(sp => new UserController(sp.GetRequiredService<IUserService>()));
        }
    }

    public class ServiceProviderControllerActivator : IHttpControllerActivator
    {
        private readonly IServiceProvider _provider;

        public ServiceProviderControllerActivator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var scopeFactory = _provider.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            request.RegisterForDispose(scope);

            return scope.ServiceProvider.GetService(controllerType) as IHttpController;
        }
    }
}
