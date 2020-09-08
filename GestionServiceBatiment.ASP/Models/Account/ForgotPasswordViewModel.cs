﻿using System.ComponentModel.DataAnnotations;

namespace GestionServiceBatiment.ASP.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}