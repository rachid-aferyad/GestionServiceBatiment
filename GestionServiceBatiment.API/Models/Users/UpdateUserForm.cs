using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GestionServiceBatiment.API.Models.Users
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
		public string LastName { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2)]
		public string FirstName { get; set; }
		//[Required]
		//[StringLength(20, MinimumLength = 8)]
		//public string Password { get; set; }
		//[Required]
		[DataType(DataType.Date)]
		public DateTime? BirthDate { get; set; }
	}
}
