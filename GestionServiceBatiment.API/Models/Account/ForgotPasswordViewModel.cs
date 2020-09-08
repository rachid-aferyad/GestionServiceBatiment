using System.ComponentModel.DataAnnotations;

namespace GestionServiceBatiment.API.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}