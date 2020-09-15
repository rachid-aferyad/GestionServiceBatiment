using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Mappers;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using GestionServiceBatiment.DAL.Views.Projects;

namespace GestionServiceBatiment.DAL.Repositories.Implementations
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteService");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Service> GetAll()
        {
            Command command = new Command("CSP_GetAllServices");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Service>());
        }

        public IEnumerable<VServiceListing> GetAllServicesListing()
        {
            Command command = new Command("CSP_GetAllServices");
            return _connection.ExecuteReader(command, reader => reader.MapTo<VServiceListing>());
        }

        public IEnumerable<VServiceListing> GetByCategory(int categoryId)
        {
            Command command = new Command("CSP_GetServicesByCategory");
            command.AddParameter("CategoryId", categoryId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VServiceListing>());
        }

        public IEnumerable<VServiceListing> GetByCompany(int companyId)
        {
            Command command = new Command("CSP_GetServicesByCompany");
            command.AddParameter("CompanyId", companyId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VServiceListing>());
        }

        public Service GetById(int id)
        {
            Command command = new Command("CSP_GetServiceById");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Service>()).SingleOrDefault();
        }

        public VServiceDetails GetServiceDetailsById(int id)
        {
            Command command = new Command("CSP_GetServiceById");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VServiceDetails>()).SingleOrDefault();
        }

        public int Insert(Service entity)
        {
            Command command = new Command("CSP_AddService");
            command.AddParameter("Title", entity.Title);
            command.AddParameter("Description", (object)entity.Description ?? DBNull.Value);
            command.AddParameter("ImageURI", (object)entity.ImageURI ?? DBNull.Value);
            command.AddParameter("CategoryId", entity.CategoryId);
            command.AddParameter("CompanyId", entity.CompanyId);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(Service entity)
        {
            Command command = new Command("CSP_UpdateService");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("Name", entity.Title);
            command.AddParameter("Description", (object)entity.Description ?? DBNull.Value);
            command.AddParameter("ImageURI", (object)entity.ImageURI ?? DBNull.Value);
            command.AddParameter("CategoryId", entity.CategoryId);
            return (int)_connection.ExecuteScalar(command) > 0;
        }
    }
}
