using GestionServiceBatiment.DAL.Views.Services;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionServiceBatiment.DAL.Views.Requests;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface IRequestRepository : IRepository<int, Request>
    {
        IEnumerable<VRequestListing> GetByCategory(int categoryId);
        IEnumerable<VRequestListing> GetByCreator(int creatorId);
        IEnumerable<VRequestListing> GetLatestRequests();
        VRequestDetails GetRequestDetailsById(int id);
    }
}
