using GestionServiceBatiment.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface IModificationService : IService<int, ModificationBO>
    {
        IEnumerable<ModificationBO> GetByService(int serviceId);
        IEnumerable<ModificationBO> GetByUser(int userId);
        IEnumerable<ModificationBO> GetByCompany(int companyId);
    }
}
