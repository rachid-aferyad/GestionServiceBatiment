using GestionServiceBatiment.API.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.API.Models.Companies
{
    public class CompanyListing
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string VatNumber { get; set;}
        public string AddressStreet { get; set;}
        public int AddressNumber { get; set;}
        public string AddressMailBox { get; set;}
        public string AddressCity { get; set;}
        public int AddressZipCode { get; set;}
        public string AddressCountry { get; set;}
        public int ContractorId { get; set;}
        public DisplayUser Contractor { get; set; }
    }
}
