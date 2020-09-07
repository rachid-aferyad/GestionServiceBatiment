using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Models.Users
{
    public enum UserRole
    {
        [Display(Name = "Utilisateur simple")]
        USER_SIMPLE = 1,
        [Display(Name = "Entrepreneur")]
        CONTRACTOR = 2,
        [Display(Name = "Admin")]
        ADMIN = 4
    }
}