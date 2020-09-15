using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Models.Comments
{
    public class CreateCommentForm
    {
        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Content { get; set; }
        [Range(0, 5)]
        public int Star { get; set; }
        [Required]
        public int CreatorId { get; set; }
        public int? CompanyId { get; set; }
        public int? ServiceId { get; set; }
        public int? RequestId { get; set; }
    }
}
