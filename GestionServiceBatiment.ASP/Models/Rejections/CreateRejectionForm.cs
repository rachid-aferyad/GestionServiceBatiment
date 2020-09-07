using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Rejections
{
    public class CreateRejectionForm
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 999999999)]
        public int RejectorId { get; set; }
        [Required]
        [Range(1, 999999999)]
        public int ServiceId { get; set; }
        public DateTime RejectionDate { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 15)]
        public string Comment { get; set; }
    }
}
