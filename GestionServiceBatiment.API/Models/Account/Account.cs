﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.API.Models.Account
{
    public class Account
    {
		public int Id { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}