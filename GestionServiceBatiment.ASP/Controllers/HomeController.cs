using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
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

namespace GestionServiceBatiment.ASP.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService _categoryService;
        private IServiceService _serviceService;
        private IRequestService _requestService;
        private ICompanyService _companyService;
        private ICommentService _commentService;
        
        public HomeController(ICategoryService categoryService, 
            IServiceService serviceService, 
            IRequestService requestService,
            ICompanyService companyService,
            ICommentService commentService)
        {
            _categoryService = categoryService;
            _serviceService = serviceService;
            _requestService = requestService;
            _companyService = companyService;
            _commentService = commentService;
        }
        
        // GET: Category
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.NumberOfServices = _serviceService.GetAll().Count();
            homeViewModel.RecentRequests = _requestService.GetAll()
                .OrderByDescending(r => r.CreationDate).Take(6)
                .Select(r => r.MapTo<DisplayRequest>());
            homeViewModel.CategoryList = _categoryService.GetSupCategories().Select(r => r.MapTo<DisplayCategory>());
            homeViewModel.MostRatedProviders = _companyService.GetAll()
                .OrderByDescending(company => _commentService.GetByCompany(company.Id).Sum(comment => comment.Star))
                .Select(company => company.MapTo<DisplayCompany>());
            homeViewModel.LatestReviews = _commentService.GetAll()
                .OrderByDescending(c => c.CreationDate)
                .Select(c => c.MapTo<DisplayComment>());

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