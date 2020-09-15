using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Models.Companies
{
    public class CreateCompanyForm
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DisplayName("Nom")]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 9)]
        [DisplayName("TVA")]
        public string VatNumber { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        [DisplayName("Adresse")]
        public string AddressStreet { get; set; }
        [Required]
        [Range(1, 1000)]
        [DisplayName("Numéro")]
        public int AddressNumber { get; set; }
        [MaxLength(50)]
        [DisplayName("Boite")]
        public string AddressMailBox { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Ville")]
        public string AddressCity { get; set; }
        [Required]
        [Range(1000, 9999)]
        [DisplayName("Code postal")]
        public int AddressZipCode { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Pays")]
        public string AddressCountry { get; set; }
        [Required]
        [Range(1, 1000000)]
        [DisplayName("Prestataire")]
        public int ContractorId { get; set; }
    }
}
