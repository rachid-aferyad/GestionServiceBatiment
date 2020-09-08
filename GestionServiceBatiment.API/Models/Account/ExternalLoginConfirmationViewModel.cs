﻿using System.ComponentModel.DataAnnotations;

namespace GestionServiceBatiment.API.Models.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}