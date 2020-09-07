using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.API.Models.Categories
{
    public class UpdateCategoryForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
