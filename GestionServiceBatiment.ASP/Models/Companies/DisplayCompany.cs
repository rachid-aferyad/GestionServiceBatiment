using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Models.Companies
{
    public class DisplayCompany
    {
        public int Id { get; set;  }
        [DisplayName("Nom")]
        public string Name { get; set;}
        [DisplayName("TVA")]
        public string VatNumber { get; set;}
        [DisplayName("Rue")]
        public string AddressStreet { get; set;}
        [DisplayName("Numéro")]
        public int AddressNumber { get; set;}
        [DisplayName("Boite")]
        public string AddressMailBox { get; set;}
        [DisplayName("Ville")]
        public string AddressCity { get; set;}
        [DisplayName("Code postal")]
        public int AddressZipCode { get; set;}
        [DisplayName("Pays")]
        public string AddressCountry { get; set;}
        [DisplayName("Prestataire")]
        public int ContractorId { get; set; }
    }
}
