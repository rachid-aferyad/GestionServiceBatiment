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
using Tools.Mappers;

namespace GestionServiceBatiment.API.Controllers
{
    public class RequestController : ApiController
    {
        private readonly IRequestService _requestService;
        private readonly IMappersService _mappersService;

        public RequestController(IRequestService requestService, IMappersService mappersService)
        {
            _requestService = requestService;
            _mappersService = mappersService;
        }

        // GET: api/Request
        public IEnumerable<RequestListing> Get()
        {
            return _requestService.GetAll().Select(c => _mappersService.Map<RequestBO, RequestListing>(c));
        }

        // GET: api/Request/5
        public DisplayRequest Get(int id)
        {
            return _mappersService.Map<RequestBO, DisplayRequest>(_requestService.GetRequestDetailsById(id));
        }

        [Route("api/Request/Category/{categoryId}")]
        public IEnumerable<RequestListing> GetByCategory(int categoryId)
        {
            return _requestService.GetByCategory(categoryId).Select(s => _mappersService.Map<RequestBO, RequestListing>(s));
        }

        [Route("api/Request/LatestRequests")]
        public IEnumerable<RequestListing> GetLatestRequests()
        {
            return _requestService.GetLatestRequests().Select(s => _mappersService.Map<RequestBO, RequestListing>(s));
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
                int requestId = _requestService.Insert(_mappersService.Map<CreateRequestForm, RequestBO>(createRequestForm));
                
                return Request.CreateResponse(HttpStatusCode.OK, requestId);
            }
            catch(Exception ex)
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
                _requestService.Update(id, _mappersService.Map<UpdateRequestForm, RequestBO>(updateRequestForm));

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
