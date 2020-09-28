﻿using GestionServiceBatiment.API.Controllers;
using GestionServiceBatiment.BLL.Services.Implementations;
using GestionServiceBatiment.BLL.Services.Interfaces;
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
using GestionServiceBatiment.BLL.Models;
using Tools.Mappers;
using GestionServiceBatiment.API.Mappers;
using GestionServiceBatiment.BLL.Mappers;

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
                defaults: new { controller = "Home", id = RouteParameter.Optional }
            );
        }

        public static void InitializeServices(IServiceCollection services)
        {
            // Add services
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IModificationRepository, ModificationRepository>();
            services.AddTransient<IRejectionRepository, RejectionRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddSingleton<ICompanyService, CompanyService>();
            services.AddTransient<IModificationService, ModificationService>();
            services.AddTransient<IRejectionService, RejectionService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddSingleton<IServiceService, ServiceService>();
            services.AddTransient<IUserService, UserService>();

            // Add mappers
            services.AddSingleton<IMappersService, MapperAPI>();
            //services.Add<IMappersService, MapperBLL>();
            
            // Add controllers
            services.AddScoped<CategoryController>(sp => new CategoryController(sp.GetRequiredService<ICategoryService>(), 
                                                                                sp.GetRequiredService<IMappersService>()
                                                                                ));

            services.AddScoped<CommentController>(sp => new CommentController(sp.GetRequiredService<ICommentService>(), 
                                                                              sp.GetRequiredService<IMappersService>()
                                                                              ));

            services.AddScoped<CompanyController>(sp => new CompanyController(sp.GetRequiredService<ICompanyService>(), sp.GetRequiredService<IMappersService>()));
            services.AddScoped<ModificationController>(sp => new ModificationController(sp.GetRequiredService<IModificationService>()));
            services.AddScoped<RejectionController>(sp => new RejectionController(sp.GetRequiredService<IRejectionService>()));
            services.AddScoped<RequestController>(sp => new RequestController(sp.GetRequiredService<IRequestService>(), sp.GetRequiredService<IMappersService>()));

            services.AddScoped<ServiceController>(sp => new ServiceController(sp.GetRequiredService<IServiceService>(), 
                                                                              sp.GetRequiredService<ICommentService>(), 
                                                                              sp.GetRequiredService<IMappersService>()));
            services.AddScoped<UserController>(sp => new UserController(sp.GetRequiredService<IUserService>()));

            //services.AddTransient<ServiceBO>();

            //services.AddScoped<ServiceBO>(sp =>
            //    new ServiceBO(sp.GetRequiredService<ICompanyService>(),
            //        sp.GetRequiredService<ICategoryService>(),
            //        sp.GetRequiredService<IUserService>(),
            //        sp.GetRequiredService<ICommentService>())
            //    );

            //services.AddScoped<CommentBO>(sp => new CommentBO(sp.GetRequiredService<IUserService>()) );

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
