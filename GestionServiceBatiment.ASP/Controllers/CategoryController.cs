using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
using GestionServiceBatiment.ASP.Models.Categories;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        [Route("Services")]
        [Route("Requests")]
        [Route("Categories")]
        [Route("Service")]
        [Route("Request")]
        public ActionResult Index()
        {
            string path = Request.Path;
            return View(_categoryService.GetSupCategories().Select(c => c.MapTo<DisplayCategory>()));
        }

        [Route("Services/{parentName}")]
        [Route("Requests/{parentName}")]
        [Route("Categories/{parentName}")]
        [Route("Service/{parentName}")]
        [Route("Request/{parentName}")]
        public ActionResult Index(string parentName)
        {
            return View(_categoryService.GetSubCategoriesByName(parentName).Select(c => c.MapTo<DisplayCategory>()));
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(_categoryService.GetById(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            CreateCategoryForm createCategoryForm = new CreateCategoryForm();
            createCategoryForm.SupCategories = _categoryService.GetSupCategories()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() })
                .ToList();

            return View(createCategoryForm);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CreateCategoryForm categoryForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Post(categoryForm.MapTo<Category>());
                    return RedirectToAction("Index");
                }

                return View(categoryForm);
            }
            catch
            {
                return View(categoryForm);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _categoryService.GetById(id);
            if(category is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category.MapTo<UpdateCategoryForm>());
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateCategoryForm updateCategoryForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Put(id, updateCategoryForm.MapTo<Category>());
                    return RedirectToAction(nameof(Index));
                }

                return View(updateCategoryForm);
            }
            catch
            {
                return View(updateCategoryForm);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                _categoryService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(category);
            }
        }
    }
}
