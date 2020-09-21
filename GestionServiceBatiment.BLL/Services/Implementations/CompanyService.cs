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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserService _userService;

        public CompanyService()
        {
        }

        public CompanyService(ICompanyRepository companyRepository, IUserService userService)
        {
            _companyRepository = companyRepository;
            _userService = userService;
        }

        public bool Delete(int id)
        {
            return _companyRepository.Delete(id);
        }

        public IEnumerable<CompanyBO> GetAll()
        {
            return _companyRepository.GetAll().Select(c => c.MapTo<CompanyBO>());
        }

        public CompanyBO GetById(int id)
        {
            CompanyBO companyBO = _companyRepository.GetById(id).MapTo<CompanyBO>();
            companyBO.Contractor = _userService.GetById(companyBO.ContractorId);
            return companyBO;
        }

        public int Insert(CompanyBO entity)
        {
            return _companyRepository.Insert(entity.MapTo<Company>());
        }

        public bool Update(int id, CompanyBO entity)
        {
            Company company = entity.MapTo<Company>();
            company.Id = id;
            return _companyRepository.Update(company);
        }
    }
}
