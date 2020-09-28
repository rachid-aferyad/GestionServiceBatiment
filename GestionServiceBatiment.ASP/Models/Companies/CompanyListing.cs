using GestionServiceBatiment.ASP.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Models.Companies
{
    public class CompanyListing
    {
        public int Id { get; set;  }
        [DisplayName("Nom de l'entreprise")]
        public string Name { get; set;}
        [DisplayName("TVA")]
        public int ContractorId { get; set; }
        public DisplayUser Contractor { get; set; }
    }
}
