using GestionServiceBatiment.DAL.Views.Services;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface IServiceRepository : IRepository<int, Service>
    {
        IEnumerable<VServiceListing> GetAllServicesListing();
        VServiceDetails GetServiceDetailsById(int id);
        IEnumerable<Service> GetByCategory(int categoryId);
        IEnumerable<VServiceListing> GetByCompany(int companyId);
        //IEnumerable<VServiceListing> GetByCategoryName(string categoryName);
    }
}
