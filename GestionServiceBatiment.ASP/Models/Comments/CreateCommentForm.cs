using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Models.Comments
{
    public class CreateCommentForm
    {
        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Content { get; set; }
        [Range(0, 5)]
        [HiddenInput]
        public int Star { get; set; }
        [Required]
        [HiddenInput]
        public int CreatorId { get; set; }
        [HiddenInput]
        public int? CompanyId { get; set; }
        [HiddenInput]
        public int? ServiceId { get; set; }
        [HiddenInput]
        public int? RequestId { get; set; }
        [HiddenInput]
        public int? ParentId { get; set; }
    }
}
