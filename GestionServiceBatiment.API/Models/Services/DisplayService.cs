using GestionServiceBatiment.API.Models.Categories;
using GestionServiceBatiment.API.Models.Comments;
using GestionServiceBatiment.API.Models.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Services
{
    public class DisplayService
    {
        public int Id { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public DateTime CreationDate { get; set; }
        public int CompanyId { get; set; }
        public DisplayCompany Company { get; set; }
        public int CategoryId { get; set; }
        public DisplayCategory Category { get; set; }
        public IEnumerable<DisplayComment> Comments { get; set; }
    }
}