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
    public class ModificationService : IModificationService
    {
        private readonly IModificationRepository _modificationRepository;
        private readonly IServiceService _serviceService;
        public ModificationService(IModificationRepository modificationRepository, IServiceService serviceService)
        {
            _modificationRepository = modificationRepository;
            _serviceService = serviceService;
        }

        public bool Delete(int id)
        {
            return _modificationRepository.Delete(id);
        }

        public IEnumerable<ModificationBO> GetAll()
        {
            return _modificationRepository.GetAll().Select(m => m.MapTo<ModificationBO>());
        }

        public IEnumerable<ModificationBO> GetByCompany(int companyId)
        {
            List<ModificationBO> modifications = new List<ModificationBO>();
            foreach (ServiceBO service in _serviceService.GetByCompany(companyId))
            {
                modifications.AddRange(GetByService(service.Id));
            }
            return modifications;
        }

        public ModificationBO GetById(int id)
        {
            return _modificationRepository.GetById(id).MapTo<ModificationBO>();
        }

        public IEnumerable<ModificationBO> GetByService(int serviceId)
        {
            return _modificationRepository.GetByService(serviceId).Select(m => m.MapTo<ModificationBO>());
        }

        public IEnumerable<ModificationBO> GetByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public int Insert(ModificationBO entity)
        {
            return _modificationRepository.Insert(entity.MapTo<Modification>());
        }

        public bool Update(int id, ModificationBO entity)
        {
            Modification modification = entity.MapTo<Modification>();
            modification.Id = id;
            return _modificationRepository.Update(modification);
        }
    }
}
