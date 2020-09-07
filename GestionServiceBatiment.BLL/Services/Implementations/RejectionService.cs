using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class RejectionService : IRejectionService
    {
        private readonly IRejectionRepository _rejectionRepository;
        private readonly IServiceService _serviceService;

        public RejectionService(IRejectionRepository rejectionRepository, IServiceService serviceService)
        {
            _rejectionRepository = rejectionRepository;
            _serviceService = serviceService;
        }

        public bool Delete(int id)
        {
            return _rejectionRepository.Delete(id);
        }

        public IEnumerable<RejectionBO> GetAll()
        {
            return _rejectionRepository.GetAll().Select(m => m.MapTo<RejectionBO>());
        }

        public IEnumerable<RejectionBO> GetByCompany(int companyId)
        {
            List<RejectionBO> rejections = new List<RejectionBO>();
            foreach (ServiceBO service in _serviceService.GetByCompany(companyId))
            {
                rejections.AddRange(GetByService(service.Id));
            }
            return rejections;
        }

        public RejectionBO GetById(int id)
        {
            return _rejectionRepository.GetById(id).MapTo<RejectionBO>();
        }

        public IEnumerable<RejectionBO> GetByService(int serviceId)
        {
            return _rejectionRepository.GetByService(serviceId).Select(r => r.MapTo<RejectionBO>());
        }

        public IEnumerable<RejectionBO> GetByRejector(int rejectorId)
        {
            return _rejectionRepository.GetByRejector(rejectorId).Select(r => r.MapTo<RejectionBO>());
        }

        public int Insert(RejectionBO entity)
        {
            return _rejectionRepository.Insert(entity.MapTo<Rejection>());
        }

        public bool Update(int id, RejectionBO entity)
        {
            Rejection rejection = entity.MapTo<Rejection>();
            rejection.Id = id;
            return _rejectionRepository.Update(rejection);
        }
    }
}
