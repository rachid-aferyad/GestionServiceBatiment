using GestionServiceBatiment.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface IRejectionService : IService<int, RejectionBO>
    {
        IEnumerable<RejectionBO> GetByRejector(int rejectorId);
        IEnumerable<RejectionBO> GetByService(int serviceId);
    }
}
