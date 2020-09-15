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
using GestionServiceBatiment.API.Models.Rejections;

namespace GestionServiceBatiment.API.Controllers
{
    public class RejectionController : ApiController
    {
        private readonly IRejectionService _rejectionService;
        public RejectionController(IRejectionService rejectionService)
        {
            _rejectionService = rejectionService;
        }

        // GET: api/Rejection
        public IEnumerable<Rejection> Get()
        {
            return _rejectionService.GetAll().Select(c => c.MapTo<Rejection>());
        }

        // GET: api/Rejection/5
        public Rejection Get(int id)
        {
            return _rejectionService.GetById(id).MapTo<Rejection>();
        }

        // POST: api/Rejection
        public HttpResponseMessage Post(CreateRejectionForm createRejectionForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _rejectionService.Insert(createRejectionForm.MapTo<RejectionBO>());
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Rejection/5
        public HttpResponseMessage Put(int id, UpdateRejectionForm updateRejectionForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _rejectionService.Update(id, updateRejectionForm.MapTo<RejectionBO>());

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Rejection/5
        public HttpResponseMessage Delete(int id)
        {
            _rejectionService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
