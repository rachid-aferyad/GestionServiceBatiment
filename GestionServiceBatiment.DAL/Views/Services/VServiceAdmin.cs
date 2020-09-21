using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Services
{
    public class VServiceAdmin
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public bool Active { get; set; }
        public bool ActivatedForValidation { get; set; }

        //Category
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //Creation
        public int CreatorId { get; set; }
        public string CreatorFirstName { get; set; }
        public string CreatorLastName { get; set; }
        public DateTime CreationDate { get; set; }

        //Validation
        public int? ValidatorId { get; set; }
        public string ValidatorFirstName { get; set; }
        public string ValidatorLastName { get; set; }
        public DateTime? ValidationDate { get; set; }
    }
}
