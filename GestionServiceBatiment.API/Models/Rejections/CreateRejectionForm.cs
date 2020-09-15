using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.API.Models.Rejections
{
    public class CreateRejectionForm
    {
        [Required]
        [Range(1, 999999999)]
        public int RejectorId { get; set; }
        [Required]
        [Range(1, 999999999)]
        public int ServiceId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 15)]
        public string Comment { get; set; }
    }
}
