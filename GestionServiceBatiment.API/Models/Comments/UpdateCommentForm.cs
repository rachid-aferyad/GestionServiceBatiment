using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.API.Models.Comments
{
    public class UpdateCommentForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Content { get; set; }
        [Range(0, 5)]
        public int Star { get; set; }
    }
}
