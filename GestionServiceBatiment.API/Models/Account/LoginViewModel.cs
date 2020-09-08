using System.ComponentModel.DataAnnotations;

namespace GestionServiceBatiment.API.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login ou Email")]
        //[EmailAddress]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}