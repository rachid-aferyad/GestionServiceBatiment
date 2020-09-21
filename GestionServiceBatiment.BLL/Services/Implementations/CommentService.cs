using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Mappers;

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private readonly IMappersService _mappersService;

        public CommentService(ICommentRepository commentRepository
            , IMappersService mappersService
            )
        {
            _commentRepository = commentRepository;
            _mappersService = mappersService;
        }

        public bool Delete(int id)
        {
            return _commentRepository.Delete(id);
        }

        public IEnumerable<CommentBO> GetAll()
        {
            return _commentRepository.GetAll().Select(c => _mappersService.Map<Comment, CommentBO>(c));
        }

        public IEnumerable<CommentBO> GetByCompany(int companyId)
        {
            return _commentRepository.GetByCompany(companyId).Select(c => _mappersService.Map<Comment, CommentBO>(c));
        }

        public IEnumerable<CommentBO> GetByCreator(int creatorId)
        {
            return _commentRepository.GetByCreator(creatorId).Select(c => _mappersService.Map<Comment, CommentBO>(c));
        }

        public CommentBO GetById(int id)
        {
            return _mappersService.Map<Comment, CommentBO>(_commentRepository.GetById(id));
        }

        public IEnumerable<CommentBO> GetByRequest(int requestId)
        {
            return _commentRepository.GetByRequest(requestId).Select(c => _mappersService.Map<Comment, CommentBO>(c));
        }

        public IEnumerable<CommentBO> GetByService(int serviceId)
        {
            IEnumerable<Comment> comments = _commentRepository.GetByService(serviceId);
            IEnumerable<CommentBO> commentsBO = comments.Select(
                c => _mappersService.Map<Comment, CommentBO>(c)
                );
            return commentsBO;
        }
        
        public IEnumerable<CommentBO> GetByParent(int parentId)
        {
            return _commentRepository.GetSubByParent(parentId).Select(c => _mappersService.Map<Comment, CommentBO>(c));
        }

        public int Insert(CommentBO entity)
        {
            return _commentRepository.Insert(entity.MapTo<Comment>());
        }

        public bool Update(int id, CommentBO entity)
        {
            Comment comment = entity.MapTo<Comment>();
            comment.Id = id;
            return _commentRepository.Update(comment);
        }
    }
}
