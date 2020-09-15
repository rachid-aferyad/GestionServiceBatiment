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

        public IEnumerable<Category> Get()
        {
            return _categoryService.GetAll().Select(c => c.MapTo<Category>());
        }

        [Route("api/Category/Sup")]
        public IEnumerable<Category> GetSup()
        {
            return _categoryService.GetSup().Select(c => c.MapTo<Category>());
        }

        [Route("api/Category/Sub/{id:int:min(1)}")]
        public IEnumerable<Category> GetSub(int id)
        {
            return _categoryService.GetSub(id).Select(c => c.MapTo<Category>());
        }

        [Route("api/Category/Sub/ParentName/{parentName}")]
        public IEnumerable<Category> GetSubByParentName(string parentName)
        {
            return _categoryService.GetSubByParentName(parentName).Select(c => c.MapTo<Category>());
        }

        [Route("api/Category/{id}:int:min(1)")]
        public Category Get(int id)
        {
            return _categoryService.GetById(id).MapTo<Category>();
        }

        [Route("api/Category/Name/{name:alpha:int}")]
        public Category GetByName(string param)
        {
            return _categoryService.GetByName(param).MapTo<Category>();
        }

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

        public HttpResponseMessage Put(int param, UpdateCategoryForm updateCategoryForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _categoryService.Update(param, updateCategoryForm.MapTo<CategoryBO>());

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Delete(int param)
        {
            _categoryService.Delete(param);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
