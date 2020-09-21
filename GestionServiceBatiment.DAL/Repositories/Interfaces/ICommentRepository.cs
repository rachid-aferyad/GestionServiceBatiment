using GestionServiceBatiment.DAL.Views.Services;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<int, Comment>
    {
        IEnumerable<Comment> GetByCreator(int creatorId);
        IEnumerable<Comment> GetByCompany(int companyId);
        IEnumerable<Comment> GetByService(int serviceId);
        IEnumerable<Comment> GetByRequest(int requestId);
        IEnumerable<Comment> GetSubByParent(int parentId);
    }
}
