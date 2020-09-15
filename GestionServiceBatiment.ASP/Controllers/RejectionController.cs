using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
using GestionServiceBatiment.ASP.Models.Modifications;
using GestionServiceBatiment.ASP.Models.Rejections;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class RejectionController : Controller
    {
        private IRejectionService _rejectionService;
        public RejectionController(IRejectionService rejectionService)
        {
            _rejectionService = rejectionService;
        }
        // GET: Rejection
        public ActionResult Index()
        {
            return View(_rejectionService.GetAll().Select(s => s.MapTo<DisplayRejection>()));
        }

        // GET: Rejection/Details/5
        public ActionResult Details(int id)
        {
            return View(_rejectionService.GetById(id).MapTo<DisplayRejection>());
        }

        // GET: Rejection/Create
        public ActionResult Create()
        {
            return View(new CreateRejectionForm());
        }

        // POST: Rejection/Create
        [HttpPost]
        public ActionResult Create(CreateRejectionForm rejectionForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _rejectionService.Post(rejectionForm.MapTo<Rejection>());
                    return RedirectToAction("Index");
                }

                return View(rejectionForm);
            }
            catch
            {
                return View(rejectionForm);
            }
        }

        // GET: Rejection/Edit/5
        public ActionResult Edit(int id)
        {
            Rejection rejection = _rejectionService.GetById(id);
            if(rejection is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(rejection.MapTo<UpdateRejectionForm>());
        }

        // POST: Rejection/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateRejectionForm updateRejectionForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _rejectionService.Put(id, updateRejectionForm.MapTo<Rejection>());
                    return RedirectToAction(nameof(Index));
                }

                return View(updateRejectionForm);
            }
            catch
            {
                return View(updateRejectionForm);
            }
        }

        // GET: Rejection/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: Rejection/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _rejectionService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
