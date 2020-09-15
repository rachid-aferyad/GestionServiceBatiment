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
using GestionServiceBatiment.API.Models.Requests;

namespace GestionServiceBatiment.API.Controllers
{
    public class RequestController : ApiController
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: api/Request
        public IEnumerable<Request> Get()
        {
            return _requestService.GetAll().Select(c => c.MapTo<Request>());
        }

        // GET: api/Request/5
        public Request Get(int id)
        {
            return _requestService.GetById(id).MapTo<Request>();
        }

        // POST: api/Request
        public HttpResponseMessage Post(CreateRequestForm createRequestForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _requestService.Insert(createRequestForm.MapTo<RequestBO>());
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Request/5
        public HttpResponseMessage Put(int id, UpdateRequestForm updateRequestForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _requestService.Update(id, updateRequestForm.MapTo<RequestBO>());

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Request/5
        public HttpResponseMessage Delete(int id)
        {
            _requestService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
