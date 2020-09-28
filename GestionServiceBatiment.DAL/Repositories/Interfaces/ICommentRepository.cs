using GestionServiceBatiment.DAL.Views;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionServiceBatiment.DAL.Views.Comments;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<int, Comment>
    {
        IEnumerable<VComment> GetByCreator(int creatorId);
        IEnumerable<VComment> GetByCompany(int companyId);
        IEnumerable<VComment> GetByService(int serviceId);
        IEnumerable<VComment> GetByRequest(int requestId);
        IEnumerable<VComment> GetSubByParent(int parentId);
        IEnumerable<VComment> GetLatestReviews();
    }
}
