using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Services
{
    public class VServiceDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public DateTime CreationDate { get; set; }

        // Category
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int? CategoryParentId {get; set; }
        public string CategoryParentName { get; set; }
        public string CategoryParentDescription {get; set;}

        // Company
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyVatNumber { get; set;}
        public string CompanyAddressMailBox { get; set; }
        public int CompanyAddressNumber {get; set;}
        public string CompanyAddressStreet {get; set;}
        public string CompanyAddressCity {get; set;}
        public int CompanyAddressZipCode {get; set;}
        public string CompanyAddressCountry {get; set;}
      
        // Contractor
        public int ContractorId { get; set;}
        public string ContractorLogin {get; set;}
        public string ContractorEmail {get; set;}
        public string ContractorLastName {get; set;}
        public string ContractorFirstName {get; set;}
        public DateTime? ContractorBirthDate {get; set;}

    }
}
