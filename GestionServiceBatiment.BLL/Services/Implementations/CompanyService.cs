using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Views.Companies;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Mappers;

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserService _userService;
        private readonly IMappersService _mappersService;

        public CompanyService(ICompanyRepository companyRepository, IUserService userService, IMappersService mappersService)
        {
            _companyRepository = companyRepository;
            _userService = userService;
            _mappersService = mappersService;
        }

        public bool Delete(int id)
        {
            return _companyRepository.Delete(id);
        }

        public IEnumerable<CompanyBO> GetAll()
        {
            return _companyRepository.GetAll().Select(c => _mappersService.Map<Company, CompanyBO>(c));
        }

        public CompanyBO GetById(int id)
        {
            CompanyBO companyBO = _mappersService.Map<Company, CompanyBO>(_companyRepository.GetById(id));
            companyBO.Contractor = _userService.GetById(companyBO.ContractorId);
            return companyBO;
        }

        public IEnumerable<CompanyBO> GetMostRatedProviders()
        {
            return _companyRepository.GetMostRatedProviders().Select(c => _mappersService.Map<VCompanyListing, CompanyBO>(c));
        }

        public int Insert(CompanyBO entity)
        {
            return _companyRepository.Insert(_mappersService.Map<CompanyBO, Company>(entity));
        }

        public bool Update(int id, CompanyBO entity)
        {
            Company company = _mappersService.Map<CompanyBO, Company>(entity);
            company.Id = id;
            return _companyRepository.Update(company);
        }
    }
}
