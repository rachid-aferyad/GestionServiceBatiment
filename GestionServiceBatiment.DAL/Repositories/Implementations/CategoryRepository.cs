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
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {

        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteCategory");
            //command.AddParameter("Table", "Category");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Category> GetAll()
        {
            Command command = new Command("CSP_GetAllCategories");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>());
        }

        public Category GetById(int id)
        {
            Command command = new Command("CSP_GetCategoryById");
            //command.AddParameter("Table", "Category");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>()).SingleOrDefault();
        }

        public IEnumerable<Category> GetByService(int serviceId)
        {
            Command command = new Command("CSP_GetByService");
            command.AddParameter("Table", "Category");
            command.AddParameter("ServiceId", serviceId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>());
        }

        public int Insert(Category entity)
        {
            Command command = new Command("CSP_AddCategory");
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(Category entity)
        {
            Command command = new Command("CSP_UpdateCategory");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            return _connection.ExecuteNonQuery(command) > 0;

        }
    }
}
