using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.BLL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.API.Models.Services;
using GestionServiceBatiment.API.Models.Companies;
using GestionServiceBatiment.API.Models.Comments;
using Tools.Mappers;
using GestionServiceBatiment.API.Models.Categories;
using GestionServiceBatiment.API.Models.Users;

namespace GestionServiceBatiment.API.Controllers
{
    public class ServiceController : ApiController
    {
        private readonly IServiceService _serviceService;
        private readonly ICommentService _commentService;
        private readonly IMappersService _mappersService;

        public ServiceController(IServiceService serviceService, ICommentService commentService, IMappersService mappersService)
        {
            _serviceService = serviceService;
            _commentService = commentService;
            _mappersService = mappersService;
        }

        // GET: api/Service
        public IEnumerable<Service> Get()
        {
            return _serviceService.GetAll().Select(c => _mappersService.Map<ServiceBO, Service>(c));
        }

        // GET: api/Service/5
        public DisplayService Get(int id)
        {
            ServiceBO serviceBO = _serviceService.GetById(id);
            DisplayService displayService = _mappersService.Map<ServiceBO, DisplayService>(serviceBO);
            return displayService;
        }

        [Route("api/Service/Category/{categoryId}")]
        public IEnumerable<DisplayService> GetByCategory(int categoryId)
        {
            return _serviceService.GetByCategory(categoryId).Select(s => _mappersService.Map<ServiceBO, DisplayService>(s));
        }

        //[Route("Service/CategoryName/{categoryName}")]
        //public Service GetByCategoryName(string categoryName)
        //{
        //    return _serviceService.GetByCategoryName(categoryName).MapTo<Service>();
        //}

        // POST: api/Service
        public HttpResponseMessage Post(CreateServiceForm createServiceForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                int serviceId = _serviceService.Insert(_mappersService.Map<CreateServiceForm, ServiceBO>(createServiceForm));
                
                return Request.CreateResponse(HttpStatusCode.OK, serviceId);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Service/5
        public HttpResponseMessage Put(int id, UpdateServiceForm updateServiceForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _serviceService.Update(id, _mappersService.Map<UpdateServiceForm, ServiceBO>(updateServiceForm));

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Service/5
        public HttpResponseMessage Delete(int id)
        {
            _serviceService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
