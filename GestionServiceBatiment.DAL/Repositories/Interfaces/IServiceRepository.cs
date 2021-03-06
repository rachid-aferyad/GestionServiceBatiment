﻿using GestionServiceBatiment.DAL.Views.Projects;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories
{
    public interface IServiceRepository : IRepository<int, Service>
    {
        IEnumerable<VServiceListing> GetAllServicesListing();
        VServiceDetails GetServiceDetailsById(int id);
        IEnumerable<VServiceListing> GetServicesByCategory(int categoryId);
        IEnumerable<VServiceListing> GetServicesByCompany(int companyId);
    }
}
