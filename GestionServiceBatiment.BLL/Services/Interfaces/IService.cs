using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface IService<TId, TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TId id);
        TId Insert(TEntity entity);
        bool Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
