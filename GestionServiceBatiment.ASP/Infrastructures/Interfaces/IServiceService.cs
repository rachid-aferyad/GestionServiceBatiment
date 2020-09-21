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
        IEnumerable<Service> GetByCategory(int categoryId);
        //IEnumerable<Service> GetByCategoryName(string categoryName);
    }
}