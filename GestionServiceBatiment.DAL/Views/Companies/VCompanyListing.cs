using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Companies
{
    public class VCompanyListing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string AddressStreet { get; set; }
        public int AddressNumber { get; set; }
        public string AddressMailBox { get; set; }
        public string AddressCity { get; set; }
        public int AddressZipCode { get; set; }
        public string AddressCountry { get; set; }

        // Contractor
        public int ContractorId { get; set; }
        public string Login {get; set;}
        public string Email {get; set;}
        public string LastName {get; set;}
        public string FirstName {get; set; }

    }
}
