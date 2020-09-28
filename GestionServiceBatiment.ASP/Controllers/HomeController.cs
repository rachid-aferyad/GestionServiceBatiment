using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Comments;
using GestionServiceBatiment.ASP.Models.Companies;
using GestionServiceBatiment.ASP.Models.Home;
using GestionServiceBatiment.ASP.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tools.Mappers;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IServiceService _serviceService;
        private readonly IRequestService _requestService;
        private readonly ICompanyService _companyService;
        private readonly ICommentService _commentService;
        private readonly IMappersService _mappersService;
        
        public HomeController(ICategoryService categoryService, 
            IServiceService serviceService, 
            IRequestService requestService,
            ICompanyService companyService,
            ICommentService commentService,
            IMappersService mappersService)
        {
            _categoryService = categoryService;
            _serviceService = serviceService;
            _requestService = requestService;
            _companyService = companyService;
            _commentService = commentService;
            _mappersService = mappersService;
        }
        
        // GET: Category
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            
            homeViewModel.NumberOfServices = _serviceService.GetServicesCount();

            homeViewModel.RecentRequests = _requestService.GetLatestRequests()
                                           .OrderByDescending(r => r.CreationDate);

            homeViewModel.CategoryList = _categoryService.GetSupCategories();
            
            homeViewModel.TopCategories = _categoryService.GetTopCategories();

            homeViewModel.MostRatedProviders = _companyService.GetMostRatedProviders();

            homeViewModel.LatestReviews = _commentService.GetLatestReviews()
                                          .OrderByDescending(c => c.CreationDate);

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}