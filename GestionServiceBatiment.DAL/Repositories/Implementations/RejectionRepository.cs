using GestionServiceBatiment.DAL.Mappers;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;

namespace GestionServiceBatiment.DAL.Repositories.Implementations
{
    public class RejectionRepository : BaseRepository, IRejectionRepository
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_Delete");
            command.AddParameter("Table", "Rejection");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Rejection> GetAll()
        {
            Command command = new Command("CSP_GetAll");
            command.AddParameter("Table", "Rejection");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Rejection>());
        }

        public IEnumerable<Rejection> GetByRejector(int rejectorId)
        {
            Command command = new Command("CSP_GetRejectionsByRejector");
            //command.AddParameter("Table", "Rejection");
            command.AddParameter("RejectorId", rejectorId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Rejection>());
        }

        public Rejection GetById(int id)
        {
            Command command = new Command("CSP_GetById");
            command.AddParameter("Table", "Rejection");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Rejection>()).SingleOrDefault();
        }

        public IEnumerable<Rejection> GetByService(int serviceId)
        {
            Command command = new Command("CSP_GetByService");
            command.AddParameter("Table", "Rejection");
            command.AddParameter("ServiceId", serviceId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Rejection>());
        }

        public int Insert(Rejection rejection)
        {
            Command command = new Command("CSP_AddRejection");
            command.AddParameter("ServiceId", rejection.ServiceId);
            command.AddParameter("RejectorId", rejection.RejectorId);
            command.AddParameter("Comment", rejection.Comment);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(Rejection rejection)
        {
            Command command = new Command("CSP_UpdateRejection");
            command.AddParameter("Id", rejection.Id);
            command.AddParameter("ServiceId", rejection.ServiceId);
            command.AddParameter("RejectorId", rejection.RejectorId);
            command.AddParameter("Comment", rejection.Comment);
            return _connection.ExecuteNonQuery(command) > 0;

        }
    }
}
