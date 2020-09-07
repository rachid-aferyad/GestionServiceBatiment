using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.API.Models.Companies
{
    public class DisplayCompany
    {
        public int Id { get; }
        public string Name { get; }
        public string VatNumber { get; }
        public string AddressStreet { get; }
        public int AddressNumber { get; }
        public string AddressMailBox { get; }
        public string AddressCity { get; }
        public int AddressZipCode { get; }
        public string AddressCountry { get; }
        public int ContractorId { get; }
    }
}
