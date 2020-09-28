using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class SharedController : Controller
    {
        private readonly ICategoryService _categoryService;

        public SharedController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult GetTopCategories()
        {
            return PartialView("_TopCategories", _categoryService.GetTopCategories());
        }
    }
}