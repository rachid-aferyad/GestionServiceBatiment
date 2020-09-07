﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.DAL.Views.Users
{
    public class VUser
    {
		//User
		public int Id { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime? BirthDate { get; set; }

	}
}
