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
using GestionServiceBatiment.API.Models.Modifications;

namespace GestionServiceBatiment.API.Controllers
{
    public class ModificationController : ApiController
    {
        private readonly IModificationService _modificationService;
        public ModificationController(IModificationService modificationService)
        {
            _modificationService = modificationService;
        }

        // GET: api/Modification
        public IEnumerable<Modification> Get()
        {
            return _modificationService.GetAll().Select(c => c.MapTo<Modification>());
        }

        // GET: api/Modification/5
        public Modification Get(int id)
        {
            return _modificationService.GetById(id).MapTo<Modification>();
        }

        //// POST: api/Modification
        //public HttpResponseMessage Post(CreateModificationForm createModificationForm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        }
        //        _modificationService.Insert(createModificationForm.MapTo<ModificationBO>());
                
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}

        //// PUT: api/Modification/5
        //public HttpResponseMessage Put(int id, UpdateModificationForm updateModificationForm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        }
        //        _modificationService.Update(id, updateModificationForm.MapTo<ModificationBO>());

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}

        // DELETE: api/Modification/5
        public HttpResponseMessage Delete(int id)
        {
            _modificationService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
