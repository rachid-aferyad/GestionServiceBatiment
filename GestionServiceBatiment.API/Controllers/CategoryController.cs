using GestionServiceBatiment.API.Models.Categories;
using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.BLL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionServiceBatiment.BLL.Models;

namespace GestionServiceBatiment.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetAll().Select(c => c.MapTo<Category>());
        }

        // GET: api/Category/5
        public Category Get(int id)
        {
            return _categoryService.GetById(id).MapTo<Category>();
        }

        // POST: api/Category
        public HttpResponseMessage Post(CreateCategoryForm createCategoryForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _categoryService.Insert(createCategoryForm.MapTo<CategoryBO>());
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Category/5
        public HttpResponseMessage Put(int id, UpdateCategoryForm updateCategoryForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _categoryService.Update(id, updateCategoryForm.MapTo<CategoryBO>());

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Category/5
        public HttpResponseMessage Delete(int id)
        {
            _categoryService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
