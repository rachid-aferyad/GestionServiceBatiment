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
using GestionServiceBatiment.API.Models.Services;

namespace GestionServiceBatiment.API.Controllers
{
    public class ServiceController : ApiController
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/Service
        public IEnumerable<Service> Get()
        {
            return _serviceService.GetAll().Select(c => c.MapTo<Service>());
        }

        // GET: api/Service/5
        public Service Get(int id)
        {
            return _serviceService.GetById(id).MapTo<Service>();
        }

        // POST: api/Service
        public HttpResponseMessage Post(CreateServiceForm createServiceForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _serviceService.Insert(createServiceForm.MapTo<ServiceBO>());
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
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
                _serviceService.Update(id, updateServiceForm.MapTo<ServiceBO>());

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
