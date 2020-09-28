using GestionServiceBatiment.ASP.Models;
using GestionServiceBatiment.ASP.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface IServiceService : IService<int, Service>
    {
        IEnumerable<ServiceListing> GetByCategory(int categoryId);
        DisplayService GetServiceDetailsById(int id);
        IEnumerable<ServiceListing> GetByCategoryName(string categoryName);
        int GetServicesCount();
    }
}