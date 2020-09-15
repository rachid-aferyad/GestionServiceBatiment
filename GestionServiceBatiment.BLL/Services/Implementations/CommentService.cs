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

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public bool Delete(int id)
        {
            return _commentRepository.Delete(id);
        }

        public IEnumerable<CommentBO> GetAll()
        {
            return _commentRepository.GetAll().Select(c => c.MapTo<CommentBO>());
        }

        public IEnumerable<CommentBO> GetByCompany(int companyId)
        {
            return _commentRepository.GetByCompany(companyId).Select(c => c.MapTo<CommentBO>());
        }

        public IEnumerable<CommentBO> GetByCreator(int creatorId)
        {
            return _commentRepository.GetByCreator(creatorId).Select(c => c.MapTo<CommentBO>());
        }

        public CommentBO GetById(int id)
        {
            return _commentRepository.GetById(id).MapTo<CommentBO>();
        }

        public IEnumerable<CommentBO> GetByRequest(int requestId)
        {
            return _commentRepository.GetByRequest(requestId).Select(c => c.MapTo<CommentBO>());
        }

        public IEnumerable<CommentBO> GetByService(int serviceId)
        {
            return _commentRepository.GetByService(serviceId).Select(c => c.MapTo<CommentBO>());
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
