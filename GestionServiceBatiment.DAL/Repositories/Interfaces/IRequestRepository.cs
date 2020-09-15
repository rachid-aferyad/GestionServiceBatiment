using GestionServiceBatiment.DAL.Views.Projects;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface IRequestRepository : IRepository<int, Request>
    {
        IEnumerable<Request> GetByCategory(int categoryId);
        IEnumerable<Request> GetByCreator(int creatorId);
    }
}
