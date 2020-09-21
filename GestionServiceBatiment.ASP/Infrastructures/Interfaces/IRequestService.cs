using GestionServiceBatiment.ASP.Models;
using GestionServiceBatiment.ASP.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface IRequestService : IService<int, Request>
    {
        IEnumerable<Request> GetByCategory(int categoryId);
    }
}