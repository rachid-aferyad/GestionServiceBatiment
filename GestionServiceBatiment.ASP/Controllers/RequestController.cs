using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Requests;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class RequestController : Controller
    {
        private IRequestService _requestService;
        private ICategoryService _categoryService;

        public RequestController(IRequestService requestService, ICategoryService categoryService)
        {
            _requestService = requestService;
            _categoryService = categoryService;
        }
        
        // GET: Request
        public ActionResult Index()
        {
            return View(_requestService.GetAll().Select(s => s.MapTo<DisplayRequest>()));
        }

        [Route("Requests/{subCatgeory}/{categoryName}")]
        public ActionResult Index(string categoryName)
        {
            Category category = _categoryService.GetByName(categoryName);
            return View(_requestService.GetByCategory(category.Id).Select(s => s.MapTo<DisplayRequest>()));
        }

        // GET: Request/Details/5
        [Route("Requests/{subCatgeory}/{categoryName}/{id}")]
        [Route("Request/Details/{id}")]
        public ActionResult Details(int id)
        {
            return View(_requestService.GetById(id).MapTo<DisplayRequest>());
        }

        // GET: Request/Create
        [HttpGet]
        [Route("Create-Request")]
        public ActionResult Create()
        {

            CreateRequestForm createRequestForm = new CreateRequestForm();
            createRequestForm.CategoryId = int.Parse(Request.Params["category"]);
            return View(createRequestForm);
        }

        // POST: Request/Create
        [HttpPost]
        [Route("Create-Request")]
        public ActionResult Create(CreateRequestForm requestForm)
        {
            try
            {
                requestForm.CreatorId = 17;

                if (ModelState.IsValid)
                {
                    int requestId = _requestService.Post(requestForm.MapTo<Request>());
                    return RedirectToAction(nameof(Details), new { id = requestId } );
                }

                return View(requestForm);
            }
            catch
            {
                return View(requestForm);
            }
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            Request request = _requestService.GetById(id);
            if(request is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(request.MapTo<UpdateRequestForm>());
        }

        // POST: Request/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateRequestForm updateRequestForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _requestService.Put(id, updateRequestForm.MapTo<Request>());
                    return RedirectToAction(nameof(Index));
                }

                return View(updateRequestForm);
            }
            catch
            {
                return View(updateRequestForm);
            }
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _requestService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
