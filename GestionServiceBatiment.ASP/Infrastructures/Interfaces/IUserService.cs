using GestionServiceBatiment.ASP.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface IUserService : IService<int, User>
    {
    }
}
