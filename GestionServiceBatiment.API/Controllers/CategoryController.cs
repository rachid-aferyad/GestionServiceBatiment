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
using Tools.Mappers;

namespace GestionServiceBatiment.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMappersService _mappersService;

        public CategoryController(ICategoryService categoryService, 
            IMappersService mappersService)
        {
            _categoryService = categoryService;
            _mappersService = mappersService;
        }

        public IEnumerable<DisplayCategory> Get()
        {
            return _categoryService.GetAll().Select(c => _mappersService.Map<CategoryBO, DisplayCategory>(c));
        }

        [Route("api/Category/Sup")]
        public IEnumerable<Category> GetSup()
        {
            return _categoryService.GetSup().Select(c => _mappersService.Map<CategoryBO, Category>(c));
        }

        [Route("api/Category/Top")]
        public IEnumerable<Category> GetTop()
        {
            return _categoryService.GetTop().Select(c => _mappersService.Map<CategoryBO, Category>(c));
        }

        [Route("api/Category/Sub/{id:int:min(1)}")]
        public IEnumerable<Category> GetSub(int id)
        {
            return _categoryService.GetSub(id).Select(c => _mappersService.Map<CategoryBO, Category>(c));
        }

        [Route("api/Category/Sub/ParentName/{parentName}")]
        public IEnumerable<Category> GetSubByParentName(string parentName)
        {
            return _categoryService.GetSubByParentName(parentName).Select(c => _mappersService.Map<CategoryBO, Category>(c));
        }

        [Route("api/Category/{id:int:min(1)}")]
        public Category Get(int id)
        {
            return _mappersService.Map<CategoryBO, Category>(_categoryService.GetById(id));
        }

        [Route("api/Category/Name/{name}")]
        public Category GetByName(string name)
        {
            return _mappersService.Map<CategoryBO, Category>(_categoryService.GetByName(name));
        }

        public HttpResponseMessage Post(CreateCategoryForm createCategoryForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _categoryService.Insert(_mappersService.Map<CreateCategoryForm, CategoryBO>(createCategoryForm));
                
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
                _categoryService.Update(param, _mappersService.Map<UpdateCategoryForm, CategoryBO>(updateCategoryForm));

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
