using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
using GestionServiceBatiment.ASP.Models.Modifications;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class ModificationController : Controller
    {
        private IModificationService _modificationService;
        public ModificationController(IModificationService modificationService)
        {
            _modificationService = modificationService;
        }

        // GET: Modification
        public ActionResult Index()
        {
            return View(_modificationService.GetAll().Select(s => s.MapTo<DisplayModification>()));
        }

        // GET: Modification/Details/5
        public ActionResult Details(int id)
        {
            return View(_modificationService.GetById(id).MapTo<DisplayModification>());
        }

        // GET: Modification/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: Modification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _modificationService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
