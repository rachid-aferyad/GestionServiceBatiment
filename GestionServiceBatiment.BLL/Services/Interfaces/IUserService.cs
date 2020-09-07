using GestionServiceBatiment.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface IUserService : IService<int, UserBO>
    {
        UserBO Check(UserBO entity);
        bool ActivateUser(int id);
        bool ChangePassword(int id, string password);
    }
}
