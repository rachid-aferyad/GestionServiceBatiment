using GestionServiceBatiment.ASP.Models;
using GestionServiceBatiment.ASP.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface ICommentService : IService<int, Comment>
    {
        IEnumerable<Comment> GetByCompany(int companyId);
        IEnumerable<Comment> GetByService(int serviceId);
        IEnumerable<Comment> GetByRequest(int requestId);
    }
}