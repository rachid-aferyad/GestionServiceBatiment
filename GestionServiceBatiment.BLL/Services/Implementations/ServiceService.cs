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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public bool Delete(int id)
        {
            return _serviceRepository.Delete(id);
        }

        public IEnumerable<ServiceBO> GetAll()
        {
            return _serviceRepository.GetAll().Select(s => s.MapTo<ServiceBO>());
        }

        public IEnumerable<ServiceBO> GetByCategory(int categoryId)
        {
            return _serviceRepository.GetByCategory(categoryId).Select(s => s.MapTo<ServiceBO>());
        }

        public IEnumerable<ServiceBO> GetByCompany(int companyId)
        {
            return _serviceRepository.GetByCompany(companyId).Select(s => s.MapTo<ServiceBO>());
        }

        public ServiceBO GetById(int id)
        {
            return _serviceRepository.GetById(id).MapTo<ServiceBO>();
        }

        public int Insert(ServiceBO entity)
        {
            return _serviceRepository.Insert(entity.MapTo<Service>());
        }

        public bool Update(int id, ServiceBO entity)
        {
            Service service = entity.MapTo<Service>();
            service.Id = id;
            return _serviceRepository.Update(service);
        }
    }
}
