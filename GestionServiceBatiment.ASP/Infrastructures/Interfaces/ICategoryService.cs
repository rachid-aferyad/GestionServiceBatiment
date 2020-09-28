using GestionServiceBatiment.ASP.Models;
using GestionServiceBatiment.ASP.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface ICategoryService : IService<int, Category>
    {
        IEnumerable<CategoryListing> GetSupCategories();
        IEnumerable<CategoryListing> GetTopCategories();
        IEnumerable<CategoryListing> GetSubCategories(int categoryId);
        IEnumerable<CategoryListing> GetSubCategoriesByName(string parentName);
        DisplayCategory GetByName(string name);
    }
}