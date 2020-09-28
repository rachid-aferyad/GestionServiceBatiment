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
using Tools.Mappers;
using GestionServiceBatiment.API.Mappers;

namespace GestionServiceBatiment.API.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;
        private readonly IMappersService _mappersService;
        
        public CommentController(ICommentService commentService, IMappersService mappersService)
        {
            _commentService = commentService;
            _mappersService = mappersService;
        }

        [Route("api/Comments")]
        public IEnumerable<Comment> Get()
        {
            return _commentService.GetAll().Select(c => _mappersService.Map<CommentBO, Comment>(c));
        }

        [Route("api/Comments/{id:int:min(1)}")]
        public Comment Get(int id)
        {
            return _mappersService.Map<CommentBO, Comment>(_commentService.GetById(id));
        }
        
        [Route("api/Company/{companyId:int:min(1)}/Comments")]
        public IEnumerable<DisplayComment> GetByCompany(int companyId)
        {
            return _commentService.GetByCompany(companyId).Select(c => _mappersService.Map<CommentBO, DisplayComment>(c));
        }

        // GET: api/Comment/5
        [Route("api/Service/{serviceId:int:min(1)}/Comments")]
        public IEnumerable<DisplayComment> GetByService(int serviceId)
        {
            IEnumerable<DisplayComment> comments = _commentService.GetByService(serviceId).Select(c => _mappersService.Map<CommentBO, DisplayComment>(c));
            return comments;
        }

        // GET: api/Comment/5
        [Route("api/Request/{requestId:int:min(1)}/Comments")]
        public IEnumerable<DisplayComment> GetByRequest(int requestId)
        {
            return _commentService.GetByRequest(requestId).Select(c => _mappersService.Map<CommentBO, DisplayComment>(c));
        }

        [Route("api/LatestComments")]
        public IEnumerable<DisplayComment> GetLatestReviews()
        {
            return _commentService.GetLatestReviews().Select(c => _mappersService.Map<CommentBO, DisplayComment>(c));
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
                _commentService.Insert(_mappersService.Map<CreateCommentForm, CommentBO>(createCommentForm));
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
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
                _commentService.Update(id, _mappersService.Map<UpdateCommentForm, CommentBO>(updateCommentForm));

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
