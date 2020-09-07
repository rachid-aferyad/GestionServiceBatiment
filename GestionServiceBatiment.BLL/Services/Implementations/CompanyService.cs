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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
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
            return _companyRepository.GetById(id).MapTo<CompanyBO>();
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
