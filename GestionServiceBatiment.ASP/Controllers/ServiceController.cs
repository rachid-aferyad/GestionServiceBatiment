using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
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
        [Route("Category/{categoryName}")]
        public ActionResult Index(string categoryName)
        {
            categoryName = categoryName.Replace('-', ' ');
            IEnumerable<ServiceListing> displayServices = _serviceService.GetByCategoryName(categoryName);
            return View(displayServices);
        }

        // GET: Service/Details/5
        [Route("Services/{subCatgeory}/{categoryName}/{id}")]
        [Route("Service/Details/{id}")]
        public ActionResult Details(int id)
        {
            DisplayService displayService = _serviceService.GetServiceDetailsById(id);
            displayService.Comments = displayService.Comments.Count() > 0 ? displayService.Comments.BuildTree() : displayService.Comments;
            displayService.SubCategories = _categoryService.GetSubCategories((int)displayService.Category.ParentId);
            return View(displayService);
        }

        // GET: Service/Create
        [HttpGet]
        [Route("Create-Service")]
        public ActionResult Create()
        {
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

        [HttpPost]
        [Route("Service/Comments/CreateCommentForm")]
        public ActionResult CreateCommentForm(int serviceId, int parentId)
        {
            CreateCommentForm createCommentForm = new CreateCommentForm()
            {
                ServiceId = serviceId,
                ParentId = parentId,
                CreatorId = 12,
                Star = 3
            };

            return PartialView("_NewComment", createCommentForm);
        }

        [HttpPost]
        [Route("Service/Comments/AddCommentToService")]
        public ActionResult AddCommentToService(CreateCommentForm createCommentForm)
        {
            try
            {
                createCommentForm.CreatorId = 12;
                createCommentForm.Star = 3;
                if (ModelState.IsValid)
                {
                    _commentService.Post(_mappersService.Map<CreateCommentForm, Comment>(createCommentForm));
                    IEnumerable<DisplayComment> comments = _commentService.GetByService((int)createCommentForm.ServiceId).Count() > 0 ?
                        _commentService.GetByService((int)createCommentForm.ServiceId).BuildTree() : _commentService.GetByService((int)createCommentForm.ServiceId);
                    return PartialView("_Comments", comments);
                    //return RedirectToAction(nameof(GetComments));
                }
                else
                    return View(createCommentForm);
            }
            catch(Exception ex)
            {
                return View(createCommentForm);
            }
        }

        [HttpPost]
        [Route("Service/GetComments/{serviceId}")]
        public ActionResult GetComments(int serviceId)
        {
            IEnumerable<DisplayComment> comments = _commentService.GetByService(serviceId).Count() > 0 ? 
                _commentService.GetByService(serviceId).BuildTree() : _commentService.GetByService(serviceId);
            //foreach(var comment in comments.Where(c => c.ParentId == null))
            //{
            //    comment.Children = comment.GetAllDescendants();
            //}

            return PartialView("_Comments", comments);
        }

        
    }
}
