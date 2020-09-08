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
	public class UpdateUserForm
	{
		[HiddenInput]
		public int Id { get; set; }
		//[Required]
		//[StringLength(50, MinimumLength = 8)]
		//public string Login { get; set; }
		//[Required]
		//[EmailAddress]
		//public string Email { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2)]
		[DisplayName("Nom")]
		public string LastName { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2)]
		[DisplayName("Prénom")]
		public string FirstName { get; set; }
		[Required]
		[DataType(DataType.Date)]
		//[UIHint("Date")]
		[DisplayName("Date de naissance")]
		public DateTime? BirthDate { get; set; }
	}
}
