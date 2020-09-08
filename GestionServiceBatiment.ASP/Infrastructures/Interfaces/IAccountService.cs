using GestionServiceBatiment.ASP.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Infrastructures.Interfaces
{
    public interface IAccountService : IService<int, Account>
    {
        //bool Login(string returnUrl);
        //bool Login(LoginViewModel model, string returnUrl);
        //bool VerifyCode(string provider, string returnUrl, bool rememberMe);
        //bool VerifyCode(VerifyCodeViewModel model);
        //bool Register();
        //bool Register(RegisterViewModel model);
        //bool ConfirmEmail(string userId, string code);
        
        //bool ForgotPassword(ForgotPasswordViewModel model);
        //bool ForgotPasswordConfirmation();
        //bool ResetPassword(string code);
        //bool ResetPassword(ResetPasswordViewModel model);
        //bool ResetPasswordConfirmation();
        
        //bool ExternalLogin(string provider, string returnUrl);
        //bool SendCode(string returnUrl, bool rememberMe);
        //bool SendCode(SendCodeViewModel model);
        //bool ExternalLoginCallback(string returnUrl);
        //bool ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl);
        //bool LogOff();

        //bool SendEmailConfirmationTokenAsync(string userID, string subject);
    }
}
