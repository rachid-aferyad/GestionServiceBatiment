using GestionServiceBatiment.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface ICompanyService : IService<int, CompanyBO>
    {
        IEnumerable<CompanyBO> GetMostRatedProviders();
    }
}
