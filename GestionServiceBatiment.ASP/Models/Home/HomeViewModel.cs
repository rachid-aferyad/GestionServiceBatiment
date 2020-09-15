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
    public class HomeViewModel
    {
        public int NumberOfServices { get; set; }
        public IEnumerable<DisplayRequest> RecentRequests { get; set; }
        public IEnumerable<DisplayCategory> CategoryList { get; set; }
        public IEnumerable<DisplayCompany> MostRatedProviders { get; set; }
        public IEnumerable<DisplayComment> LatestReviews { get; set; }
    }
}