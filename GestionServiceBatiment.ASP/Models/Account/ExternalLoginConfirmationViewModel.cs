using System.ComponentModel.DataAnnotations;

namespace GestionServiceBatiment.ASP.Models.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}