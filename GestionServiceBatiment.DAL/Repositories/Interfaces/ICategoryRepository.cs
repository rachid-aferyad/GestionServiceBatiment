using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<int, Category>
    {
        IEnumerable<Category> GetSup();
        IEnumerable<Category> GetSub(int categoryId);
        Category GetByName(string name);
        IEnumerable<Category> GetSubByParentName(string parentName);
    }
}
