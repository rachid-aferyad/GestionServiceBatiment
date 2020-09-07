using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Models.Services
{
    public class UpdateServiceForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public string ImageURI { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}