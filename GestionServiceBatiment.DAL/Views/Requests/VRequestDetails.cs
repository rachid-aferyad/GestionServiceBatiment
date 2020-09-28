using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Requests
{
    public class VRequestDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public DateTime CreationDate { get; set; }

        // Category
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int? CategoryParentId { get; set; }
        public string CategoryParentName { get; set; }
        public string CategoryParentDescription { get; set; }

        // Creator
        public int CreatorId { get; set; }
        public string CreatorLogin { get; set; }
        public string CreatorEmail { get; set; }
        public string CreatorLastName { get; set; }
        public string CreatorFirstName { get; set; }
        public DateTime? CreatorBirthDate { get; set; }
    }
}
