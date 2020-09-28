using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Services
{
    public class VServiceListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
