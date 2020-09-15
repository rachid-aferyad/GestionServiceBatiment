using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services;
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
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public bool Delete(int id)
        {
            return _requestRepository.Delete(id);
        }

        public IEnumerable<RequestBO> GetAll()
        {
            return _requestRepository.GetAll().Select(s => s.MapTo<RequestBO>());
        }

        public IEnumerable<RequestBO> GetByCategory(int categoryId)
        {
            return _requestRepository.GetByCategory(categoryId).Select(s => s.MapTo<RequestBO>());
        }

        public IEnumerable<RequestBO> GetByCreator(int creatorId)
        {
            return _requestRepository.GetByCreator(creatorId).Select(s => s.MapTo<RequestBO>());
        }

        public RequestBO GetById(int id)
        {
            return _requestRepository.GetById(id).MapTo<RequestBO>();
        }

        public int Insert(RequestBO entity)
        {
            return _requestRepository.Insert(entity.MapTo<Request>());
        }

        public bool Update(int id, RequestBO entity)
        {
            Request request = entity.MapTo<Request>();
            request.Id = id;
            return _requestRepository.Update(request);
        }
    }
}
