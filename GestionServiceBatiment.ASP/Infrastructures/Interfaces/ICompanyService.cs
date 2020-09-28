using GestionServiceBatiment.ASP.Models;
using GestionServiceBatiment.ASP.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface ICompanyService : IService<int, Company>
    {
        IEnumerable<CompanyListing> GetMostRatedProviders();
    }
}