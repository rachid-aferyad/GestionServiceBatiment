using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.API.Models.Rejections
{
    public class UpdateRejectionForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 15)]
        public string Comment { get; set; }
    }
}
