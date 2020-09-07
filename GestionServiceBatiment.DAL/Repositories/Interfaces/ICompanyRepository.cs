using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories
{
    public interface ICompanyRepository : IRepository<int, Company>
    {
        Company GetByContractor(int contractorId);
    }
}
