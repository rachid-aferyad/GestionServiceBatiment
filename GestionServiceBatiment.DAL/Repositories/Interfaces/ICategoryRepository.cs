using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Views.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<int, Category>
    {
        IEnumerable<VCategoryListing> GetSup();
        IEnumerable<VCategoryListing> GetSub(int categoryId);
        VCategoryDetails GetByName(string name);
        IEnumerable<VCategoryListing> GetSubByParentName(string parentName);
        IEnumerable<VCategoryListing> GetTop();
    }
}
