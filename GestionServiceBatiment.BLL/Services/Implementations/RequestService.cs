using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using GestionServiceBatiment.DAL.Views.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Mappers;

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly ICommentService _commentService;
        private readonly IMappersService _mappersService;
        public RequestService(IRequestRepository requestRepository, ICommentService commentService, IMappersService mappersService)
        {
            _requestRepository = requestRepository;
            _commentService = commentService;
            _mappersService = mappersService;
        }

        public bool Delete(int id)
        {
            return _requestRepository.Delete(id);
        }

        public IEnumerable<RequestBO> GetAll()
        {
            return _requestRepository.GetAll().Select(r => _mappersService.Map<Request, RequestBO>(r));
        }

        public IEnumerable<RequestBO> GetByCategory(int categoryId)
        {
            return _requestRepository.GetByCategory(categoryId).Select(r => _mappersService.Map<VRequestListing, RequestBO>(r));
        }

        public IEnumerable<RequestBO> GetByCreator(int creatorId)
        {
            return _requestRepository.GetByCreator(creatorId).Select(r => _mappersService.Map<VRequestListing, RequestBO>(r));
        }

        public RequestBO GetById(int id)
        {
            return _mappersService.Map<Request, RequestBO>(_requestRepository.GetById(id));
        }

        public RequestBO GetRequestDetailsById(int id)
        {
            RequestBO requestBO = _mappersService.Map<VRequestDetails, RequestBO>(_requestRepository.GetRequestDetailsById(id)); // _serviceRepository.GetById(id).MapTo<ServiceBO>();
            requestBO.Comments = _commentService.GetByRequest(id);

            return requestBO;
        }

        public IEnumerable<RequestBO> GetLatestRequests()
        {
            return _requestRepository.GetLatestRequests().Select(r => _mappersService.Map<VRequestListing, RequestBO>(r));
        }

        public int Insert(RequestBO entity)
        {
            return _requestRepository.Insert(_mappersService.Map<RequestBO, Request>(entity));
        }

        public bool Update(int id, RequestBO entity)
        {
            Request request = _mappersService.Map<RequestBO, Request>(entity);
            request.Id = id;
            return _requestRepository.Update(request);
        }
    }
}
