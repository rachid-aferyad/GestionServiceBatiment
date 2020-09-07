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
    public class ModificationRepository : BaseRepository, IModificationRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modification> GetAll()
        {
            Command command = new Command("CSP_GetAllModifications");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Modification>());
        }

        public Modification GetById(int id)
        {
            Command command = new Command("CSP_GetModificationById");
            //command.AddParameter("Table", "Company");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Modification>()).SingleOrDefault();
        }

        public IEnumerable<Modification> GetByService(int serviceId)
        {
            Command command = new Command("CSP_GetByService");
            command.AddParameter("Table", "Modification");
            command.AddParameter("ServiceId", serviceId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Modification>());
        }

        public int Insert(Modification entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Modification entity)
        {
            throw new NotImplementedException();
        }
    }
}
