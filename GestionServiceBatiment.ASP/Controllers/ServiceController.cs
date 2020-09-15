using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Services;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly ICategoryService _categoryService;

        public ServiceController(IServiceService serviceService, ICategoryService categoryService)
        {
            _serviceService = serviceService;
            _categoryService = categoryService;
        }
       
        // GET: Service
        public ActionResult Index()
        {
            return View(_serviceService.GetAll().Select(s => s.MapTo<DisplayService>()));
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            DisplayService displayService = _serviceService.GetById(id).MapTo<DisplayService>();
            return View(displayService);
        }

        // GET: Service/Create
        [Route("Service/Create")]
        public ActionResult Create()
        {
            //CreateServiceForm createServiceForm = new CreateServiceForm();
            IEnumerable<DisplayCategory> supCategories = _categoryService.GetAll().Select(c => c.MapTo<DisplayCategory>());

            return View(supCategories);
        }

        // GET: Service/Create
        [Route("Service/Create/{parentName}")]
        public ActionResult Create(string parentName)
        {
            //Category parent = _categoryService.GetByName(parentName);
            //CreateServiceForm createServiceForm = new CreateServiceForm();
            //createServiceForm.Categories = _categoryService.GetSubCategories(parent).Select(c => c.MapTo<DisplayCategory>());
            return View(_categoryService.GetSubCategoriesByName(parentName));
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(CreateServiceForm serviceForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceService.Post(serviceForm.MapTo<Service>());
                    return RedirectToAction("Index");
                }

                return View(serviceForm);
            }
            catch
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
            return View(service.MapTo<UpdateServiceForm>());
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateServiceForm updateServiceForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceService.Put(id, updateServiceForm.MapTo<Service>());
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
