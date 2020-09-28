using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Comments;
using GestionServiceBatiment.ASP.Models.Companies;
using GestionServiceBatiment.ASP.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Models.Home
{
    public class HomeViewModel : ViewModelBase
    {
        public int NumberOfServices { get; set; }
        public IEnumerable<RequestListing> RecentRequests { get; set; }
        public IEnumerable<CategoryListing> CategoryList { get; set; }
        public IEnumerable<CompanyListing> MostRatedProviders { get; set; }
        public IEnumerable<DisplayComment> LatestReviews { get; set; }
    }
}