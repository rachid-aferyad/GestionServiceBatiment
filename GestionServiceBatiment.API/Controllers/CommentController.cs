using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.BLL.Services.Implementations;
using GestionServiceBatiment.API.Models.Comments;
using GestionServiceBatiment.BLL.Services;
using GestionServiceBatiment.BLL.Models;

namespace GestionServiceBatiment.API.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;
        
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("api/Comments")]
        public IEnumerable<Comment> Get()
        {
            return _commentService.GetAll().Select(c => c.MapTo<Comment>());
        }

        [Route("api/Comments/{id:int:min(1)}")]
        public Comment Get(int id)
        {
            return _commentService.GetById(id).MapTo<Comment>();
        }
        
        [Route("api/Company/{companyId:int:min(1)}/Comments")]
        public IEnumerable<Comment> GetByCompany(int companyId)
        {
            return _commentService.GetByCompany(companyId).Select(c => c.MapTo<Comment>());
        }

        // GET: api/Comment/5
        [Route("api/Service/{serviceId:int:min(1)}/Comments")]
        public IEnumerable<Comment> GetByService(int serviceId)
        {
            return _commentService.GetByService(serviceId).Select(c => c.MapTo<Comment>());
        }
        
        // GET: api/Comment/5
        [Route("api/Request/{requestId:int:min(1)}/Comments")]
        public IEnumerable<Comment> GetByRequest(int requestId)
        {
            return _commentService.GetByRequest(requestId).Select(c => c.MapTo<Comment>());
        }

        // POST: api/Comment
        public HttpResponseMessage Post(CreateCommentForm createCommentForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _commentService.Insert(createCommentForm.MapTo<CommentBO>());
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Comment/5
        [Route("api/Comment/{id:int:min(1)}")]
        public HttpResponseMessage Put(int id, UpdateCommentForm updateCommentForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _commentService.Update(id, updateCommentForm.MapTo<CommentBO>());

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Comment/5
        [Route("api/Comment/{id:int:min(1)}")]
        public HttpResponseMessage Delete(int id)
        {
            _commentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
