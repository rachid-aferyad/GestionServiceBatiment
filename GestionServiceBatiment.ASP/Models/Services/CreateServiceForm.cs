using GestionServiceBatiment.ASP.Models.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Models.Services
{
    public class CreateServiceForm
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public string ImageURI { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<DisplayCategory> Categories { get; set; }
    }
}