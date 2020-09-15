using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.API.Models.Requests
{
    public class CreateRequestForm
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 15)]
        public string Description { get; set; }
        public string ImageURI { get; set; }
        [Range(1, 99999999)]
        public int CreatorId { get; set; }
        [Required]
        [Range(1, 99999999)]
        public int CategoryId { get; set; }
    }
}