using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using GestionServiceBatiment.DAL.Views.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Mappers;

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ICategoryService _categoryService;
        private readonly ICompanyService _companyService;
        private readonly ICommentService _commentService;
        private readonly IMappersService _mappersService;

        public ServiceService(IServiceRepository serviceRepository,
            ICategoryService categoryService,
            ICompanyService companyService,
            ICommentService commentService,
            IMappersService mappersService
            )
        {
            _serviceRepository = serviceRepository;
            _categoryService = categoryService;
            _companyService = companyService;
            _commentService = commentService;
            _mappersService = mappersService;
        }

        public bool Delete(int id)
        {
            return _serviceRepository.Delete(id);
        }

        public IEnumerable<ServiceBO> GetAll()
        {
            return _serviceRepository.GetAll().Select(s => _mappersService.Map<Service, ServiceBO>(s));
        }

        public IEnumerable<ServiceBO> GetByCategory(int categoryId)
        {
            IEnumerable<ServiceBO> servicesBO = _serviceRepository.GetByCategory(categoryId)
                .Select(s => _mappersService.Map<VServiceListing, ServiceBO>(s)); 
            
            
            // _serviceRepository.GetById(id).MapTo<ServiceBO>();
            //servicesBO.ToList().ForEach(s => s.Comments = _commentService.GetByService(s.Id));
            foreach (var item in servicesBO)
            {
                item.Company = _companyService.GetById(item.CompanyId);
                item.Category = _categoryService.GetById(item.CategoryId);
                item.Comments = _commentService.GetByService(item.Id);
            }
            return servicesBO;
            //return _serviceRepository.GetByCategory(categoryId).Select(s => _mappersService.Map<VServiceListing, ServiceBO>(s));
        }

        public IEnumerable<ServiceBO> GetByCategoryName(string categoryName)
        {
            CategoryBO categoryBO = _categoryService.GetByName(categoryName);
            return _serviceRepository.GetByCategory(categoryBO.Id).Select(s => _mappersService.Map<VServiceListing, ServiceBO>(s));
        }

        public IEnumerable<ServiceBO> GetByCompany(int companyId)
        {
            return _serviceRepository.GetByCompany(companyId).Select(s => _mappersService.Map<VServiceListing, ServiceBO>(s));
        }

        public ServiceBO GetById(int id)
        {
            ServiceBO serviceBO = _mappersService.Map<VServiceDetails, ServiceBO>(_serviceRepository.GetServiceDetailsById(id)); // _serviceRepository.GetById(id).MapTo<ServiceBO>();
            //serviceBO.Company = _companyService.GetById(serviceBO.CompanyId);
            //serviceBO.Category = _categoryService.GetById(serviceBO.CategoryId);
            serviceBO.Comments = _commentService.GetByService(id);

            return serviceBO;
        }

        public ServiceBO GetServiceDetailsById(int id)
        {
            ServiceBO serviceBO = _mappersService.Map<VServiceDetails, ServiceBO>(_serviceRepository.GetServiceDetailsById(id)); // _serviceRepository.GetById(id).MapTo<ServiceBO>();
            serviceBO.Comments = _commentService.GetByService(id);

            return serviceBO;
        }

        public int GetServicesCount()
        {
            return _serviceRepository.GetServicesCount();
        }

        public int Insert(ServiceBO entity)
        {
            return _serviceRepository.Insert(_mappersService.Map<ServiceBO, Service>(entity));
        }

        public bool Update(int id, ServiceBO entity)
        {
            Service service = _mappersService.Map<ServiceBO, Service>(entity);
            service.Id = id;
            return _serviceRepository.Update(service);
        }
    }
}
