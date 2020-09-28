using GestionServiceBatiment.ASP.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Models
{
    public abstract class ViewModelBase
    {
        public IEnumerable<CategoryListing> TopCategories { get; internal set; }
    }
}