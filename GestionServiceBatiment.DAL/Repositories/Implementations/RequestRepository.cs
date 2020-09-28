using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;
using GestionServiceBatiment.DAL.Repositories.Implementations;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Mappers;
using GestionServiceBatiment.DAL.Views.Requests;

namespace GestionServiceBatiment.DAL.Repositories.Implementations
{
    public class RequestRepository : BaseRepository, IRequestRepository
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteRequest");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Request> GetAll()
        {
            Command command = new Command("CSP_GetAllRequests");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Request>());
        }

        public Request GetById(int id)
        {
            Command command = new Command("CSP_GetRequestById");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Request>()).SingleOrDefault();
        }
        
        public VRequestDetails GetRequestDetailsById(int id)
        {
            Command command = new Command("CSP_GetRequestById");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VRequestDetails>()).SingleOrDefault();
        }

        public IEnumerable<VRequestListing> GetByCreator(int creatorId)
        {
            Command command = new Command("CSP_GetByUser");
            command.AddParameter("Table", "Request");
            command.AddParameter("CreatorId", creatorId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VRequestListing>());
        }

        public IEnumerable<VRequestListing> GetByCategory(int categoryId)
        {
            Command command = new Command("CSP_GetRequestsByCategory");
            command.AddParameter("CategoryId", categoryId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VRequestListing>());
        }
        
        public IEnumerable<VRequestListing> GetLatestRequests()
        {
            Command command = new Command("CSP_GetLatestRequests");
            return _connection.ExecuteReader(command, reader => reader.MapTo<VRequestListing>());
        }

        public int Insert(Request entity)
        {
            Command command = new Command("CSP_AddRequest");
            command.AddParameter("Title", entity.Title);
            command.AddParameter("Description", (object)entity.Description ?? DBNull.Value);
            command.AddParameter("ImageURI", (object)entity.ImageURI ?? DBNull.Value);
            command.AddParameter("CategoryId", entity.CategoryId);
            command.AddParameter("CreatorId", entity.CreatorId);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(Request entity)
        {
            Command command = new Command("CSP_UpdateRequest");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("Name", entity.Title);
            command.AddParameter("Description", (object)entity.Description ?? DBNull.Value);
            command.AddParameter("ImageURI", (object)entity.ImageURI ?? DBNull.Value);
            command.AddParameter("CategoryId", entity.CategoryId);
            return (int)_connection.ExecuteScalar(command) > 0;
        }

    }
}
