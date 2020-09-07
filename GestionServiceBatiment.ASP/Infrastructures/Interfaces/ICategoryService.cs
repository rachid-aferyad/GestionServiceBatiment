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
    }
}