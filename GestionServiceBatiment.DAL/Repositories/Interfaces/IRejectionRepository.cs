using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories
{
    public interface IRejectionRepository : IRepository<int, Rejection>
    {
        IEnumerable<Rejection> GetByRejector(int rejectorId);
        IEnumerable<Rejection> GetByService(int serviceId);
    }
}
