using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Views.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface ICompanyRepository : IRepository<int, Company>
    {
        VCompanyDetails GetByContractor(int contractorId);
        IEnumerable<VCompanyListing> GetMostRatedProviders();
    }
}
