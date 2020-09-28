using GestionServiceBatiment.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Interfaces
{
    public interface ICategoryService : IService<int, CategoryBO>
    {
        IEnumerable<CategoryBO> GetSup();
        IEnumerable<CategoryBO> GetSub(int categoryId);
        CategoryBO GetByName(string name);
        IEnumerable<CategoryBO> GetSubByParentName(string parentName);
        IEnumerable<CategoryBO> GetTop();
    }
}
