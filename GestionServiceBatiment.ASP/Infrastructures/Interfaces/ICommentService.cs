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
        IEnumerable<DisplayComment> GetByCompany(int companyId);
        IEnumerable<DisplayComment> GetByService(int serviceId);
        IEnumerable<DisplayComment> GetByRequest(int requestId);
        IEnumerable<DisplayComment> GetLatestReviews();
        IEnumerable<DisplayComment> GetComments(EntityType entityType, int entityId);
    }
}