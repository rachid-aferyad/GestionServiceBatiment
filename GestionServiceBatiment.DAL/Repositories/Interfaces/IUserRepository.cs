using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<int, User>
    {
        VUser Check(User entity);
        bool ActivateUser(int id);
        bool ChangePassword(int id, string password);
    }
}
