using GestionServiceBatiment.DAL.Mappers;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using GestionServiceBatiment.DAL.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;

namespace GestionServiceBatiment.DAL.Repositories.Implementations
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public bool ActivateUser(int id)
        {
            Command command = new Command("CSP_ActivateUser");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public bool ChangePassword(int id, string password)
        {
            Command command = new Command("CSP_ChangePassword");
            command.AddParameter("Id", id);
            command.AddParameter("Password", password);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public VUser Check(User user)
        {
            Command command = new Command("CSP_CheckUser");
            command.AddParameter("Email", (object)user.Email ?? DBNull.Value);
            command.AddParameter("Login", (object)user.Login ?? DBNull.Value);
            command.AddParameter("Password", user.Password);
            return _connection.ExecuteReader(command, (reader) => reader.MapTo<VUser>()).SingleOrDefault();
        }


        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteUser");
            command.AddParameter("Id", id);
            //command.AddParameter("Table", "User");
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<User> GetAll()
        {
            Command command = new Command("CSP_GetAllUsers");
            return _connection.ExecuteReader(command, (reader) => reader.MapTo<User>());
        }

        public User GetById(int id)
        {
            Command command = new Command("CSP_GetUserById");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, (reader) => reader.MapTo<User>()).SingleOrDefault();
        }

        public int Insert(User entity)
        {
            Command command = new Command("CSP_AddUser");
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Login", entity.Login);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Password", entity.Password);
            command.AddParameter("BirthDate", ((object)entity.BirthDate) ?? DBNull.Value);
            command.AddParameter("Role", entity.Role);
            //command.AddParameter("Active", entity.Active);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(User entity)
        {
            Command command = new Command("CSP_UpdateUser");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("BirthDate", (object)entity.BirthDate ?? DBNull.Value);
            //command.AddParameter("Role", entity.Role);
            return _connection.ExecuteNonQuery(command) > 0;
        }
    }
}
