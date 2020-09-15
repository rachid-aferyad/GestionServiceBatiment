using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface IModificationRepository : IRepository<int, Modification>
    {
        IEnumerable<Modification> GetByService(int serviceId);
    }
}
