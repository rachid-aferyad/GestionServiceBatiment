using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface ICommentService : IService<int, CommentBO>
    {
        IEnumerable<CommentBO> GetByCreator(int creatorId);
        IEnumerable<CommentBO> GetByCompany(int companyId);
        IEnumerable<CommentBO> GetByService(int serviceId);
        IEnumerable<CommentBO> GetByRequest(int requestId);
        IEnumerable<CommentBO> GetByParent(int parentId);
    }
}
