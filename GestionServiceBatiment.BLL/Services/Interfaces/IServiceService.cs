using GestionServiceBatiment.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface IServiceService : IService<int, ServiceBO>
    {
        IEnumerable<ServiceBO> GetByCompany(int companyId);
        IEnumerable<ServiceBO> GetByCategory(int categoryId);
        //IEnumerable<ServiceBO> GetByCategoryName(string categoryName);
    }
}
