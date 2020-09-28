using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface IRequestService : IService<int, RequestBO>
    {
        IEnumerable<RequestBO> GetByCategory(int categoryId);
        IEnumerable<RequestBO> GetByCreator(int creatorId);
        IEnumerable<RequestBO> GetLatestRequests();
        RequestBO GetRequestDetailsById(int id);
    }
}
