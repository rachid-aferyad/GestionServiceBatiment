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
        public ActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(_categoryService.GetById(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View(new CreateCategoryForm());
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _categoryService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
