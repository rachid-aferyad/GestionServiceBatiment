using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Models.Companies
{
    public class UpdateCompanyForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 9)]
        public string VatNumber { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string AddressStreet { get; set; }
        [Required]
        [Range(1, 1000)]
        public int AddressNumber { get; set; }
        [MaxLength(50)]
        public string AddressMailBox { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string AddressCity { get; set; }
        [Required]
        [Range(1000, 9999)]
        public int AddressZipCode { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string AddressCountry { get; set; }
    }
}
