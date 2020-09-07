using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Users
{
    public class VContractor
    {
		//User
		public int Id { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime? BirthDate { get; set; }

		//Company
		public string CompanyName { get; set; }
		public string CompanyVatNumber { get; set; }
		public string CompanyAddressMailBox { get; set; }
		public int CompanyAddressNumber { get; set; }
		public string CompanyAddressStreet { get; set; }
		public string CompanyAddressCity { get; set; }
		public int CompanyAddressZipCode { get; set; }
		public string CompanyAddressCountry { get; set; }

	}
}
