using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface IService<TId, TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TId id);
        int Post(TEntity entity);
        bool Put(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
