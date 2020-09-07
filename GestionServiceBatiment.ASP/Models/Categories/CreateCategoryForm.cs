using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Categories
{
    public class CreateCategoryForm
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DisplayName("Nom")]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
