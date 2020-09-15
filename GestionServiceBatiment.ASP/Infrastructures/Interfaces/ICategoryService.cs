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
        IEnumerable<Category> GetSupCategories();
        IEnumerable<Category> GetSubCategories(int categoryId);
        IEnumerable<Category> GetSubCategoriesByName(string parentName);
        Category GetByName(string name);
    }
}