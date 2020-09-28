using GestionServiceBatiment.DAL.Mappers;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using GestionServiceBatiment.DAL.Views.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;

namespace GestionServiceBatiment.DAL.Repositories.Implementations
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteCompany");
            //command.AddParameter("Table", "Company");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Company> GetAll()
        {
            Command command = new Command("CSP_GetAllCompanies");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Company>());
        }

        public VCompanyDetails GetByContractor(int contractorId)
        {
            Command command = new Command("CSP_GetCompanyByContractorId");
            //command.AddParameter("Table", "Company");
            command.AddParameter("ContractorId", contractorId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VCompanyDetails>()).SingleOrDefault();
        }

        public Company GetById(int id)
        {
            Command command = new Command("CSP_GetCompanyById");
            //command.AddParameter("Table", "Company");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Company>()).SingleOrDefault();
        }

        public IEnumerable<VCompanyListing> GetByService(int serviceId)
        {
            Command command = new Command("CSP_GetByService");
            command.AddParameter("Table", "Company");
            command.AddParameter("ServiceId", serviceId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VCompanyListing>());
        }

        public IEnumerable<VCompanyListing> GetMostRatedProviders()
        {
            Command command = new Command("CSP_GetMostRatedProviders");
            return _connection.ExecuteReader(command, reader => reader.MapTo<VCompanyListing>());
        }

        public int Insert(Company company)
        {
            Command command = new Command("CSP_AddCompany");
            command.AddParameter("Name", company.Name);
            command.AddParameter("VatNumber", company.VatNumber);
            command.AddParameter("AddressStreet", company.AddressStreet);
            command.AddParameter("AddressNumber", company.AddressNumber);
            command.AddParameter("AddressMailBox", company.AddressMailBox);
            command.AddParameter("AddressZipCode", company.AddressZipCode);
            command.AddParameter("AddressCity", company.AddressCity);
            command.AddParameter("AddressCountry", company.AddressCountry);
            command.AddParameter("ContractorId", company.ContractorId);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(Company company)
        {
            Command command = new Command("CSP_UpdateCompany");
            command.AddParameter("Id", company.Id);
            command.AddParameter("Name", company.Name);
            command.AddParameter("VatNumber", company.VatNumber);
            command.AddParameter("AddressStreet", company.AddressStreet);
            command.AddParameter("AddressNumber", company.AddressNumber);
            command.AddParameter("AddressMailBox", company.AddressMailBox);
            command.AddParameter("AddressZipCode", company.AddressZipCode);
            command.AddParameter("AddressCity", company.AddressCity);
            command.AddParameter("AddressCountry", company.AddressCountry);
            //command.AddParameter("ContractorId", company.ContractorId);
            return _connection.ExecuteNonQuery(command) > 0;

        }
    }
}
