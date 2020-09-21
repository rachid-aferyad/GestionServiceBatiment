using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Comments;
using GestionServiceBatiment.ASP.Models.Services;
using Tools.Mappers;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IMappersService _mappersService;

        public ServiceController(IServiceService serviceService, 
                                 ICategoryService categoryService, 
                                 ICommentService commentService,
                                 IMappersService mappersService
            )
        {
            _serviceService = serviceService;
            _categoryService = categoryService;
            _commentService = commentService;
            _mappersService = mappersService;
        }

        // GET: Service
        public ActionResult Index()
        {
            return View(_serviceService.GetAll().Select(s => _mappersService.Map<Service, DisplayService>(s)));
        }

        [Route("Services/{subCatgeory}/{categoryName}")]
        public ActionResult Index(string categoryName)
        {
            Category category = _categoryService.GetByName(categoryName);
            IEnumerable<DisplayService> displayServices = _serviceService.GetByCategory(category.Id).Select(
                s => _mappersService.Map<Service, DisplayService>(s));
            return View(displayServices);
        }

        // GET: Service/Details/5
        [Route("Services/{subCatgeory}/{categoryName}/{id}")]
        [Route("Service/Details/{id}")]
        public ActionResult Details(int id)
        {
            DisplayService displayService = _mappersService.Map<Service, DisplayService>(_serviceService.GetById(id));
            //IEnumerable<DisplayComment> comments = _commentService.GetByService(displayService.Id).Select(c => _mappersService.Map<Comment, DisplayComment>(c));
            //displayService.Comments = comments;
            return View(displayService);
        }

        // GET: Service/Create
        [HttpGet]
        [Route("Create-Service")]
        public ActionResult Create()
        {
            //CreateServiceForm createServiceForm = new CreateServiceForm();
            //IEnumerable<DisplayCategory> supCategories = _categoryService.GetAll().Select(c => c.MapTo<DisplayCategory>());

            CreateServiceForm createServiceForm = new CreateServiceForm();
            createServiceForm.CategoryId = int.Parse(Request.Params["category"]);

            return View(createServiceForm);
        }

        // GET: Service/Create

        //[Route("Service/Create/{category}")]
        //public ActionResult Create(int category)
        //{
        //    //Category parent = _categoryService.GetByName(parentName);
        //    //CreateServiceForm createServiceForm = new CreateServiceForm();
        //    //createServiceForm.Categories = _categoryService.GetSubCategories(parent).Select(c => c.MapTo<DisplayCategory>());

        //    CreateServiceForm createServiceForm = new CreateServiceForm();
        //    createServiceForm.CategoryId = category;

        //    return View(createServiceForm);
        //}

        // POST: Service/Create
        [HttpPost]
        [Route("Create-Service")]
        public ActionResult Create(CreateServiceForm serviceForm)
        {
            try
            {
                serviceForm.CompanyId = 17;

                if (ModelState.IsValid)
                {
                    int serviceId = _serviceService.Post(_mappersService.Map<CreateServiceForm, Service>(serviceForm));
                    return RedirectToAction(nameof(Details), new { id = serviceId });
                }

                return View(serviceForm);
            }
            catch (Exception ex)
            {
                return View(serviceForm);
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            Service service = _serviceService.GetById(id);

            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(_mappersService.Map<Service, UpdateServiceForm>(service));
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateServiceForm updateServiceForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceService.Put(id, _mappersService.Map<UpdateServiceForm, Service>(updateServiceForm));
                    return RedirectToAction(nameof(Index));
                }

                return View(updateServiceForm);
            }
            catch
            {
                return View(updateServiceForm);
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            Service service = _serviceService.GetById(id);

            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return Details(id);
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _serviceService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
