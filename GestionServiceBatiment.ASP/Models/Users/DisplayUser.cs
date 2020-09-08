using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Models.Users
{
	public class DisplayUser
	{
		[HiddenInput]
		public int Id { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		[DisplayName("Nom")]
		public string LastName { get; set; }
		[DisplayName("Prénom")]
		public string FirstName { get; set; }
		//public string Password { get; set; }
		[DisplayName("Date de naissance")]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

		public DateTime? BirthDate { get; set; }
		public bool Active { get; set; }
		public UserRole Role { get; set; }
	}
}
