using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ActivateUser(int id)
        {
            return _userRepository.ActivateUser(id);
        }

        public bool ChangePassword(int id, string password)
        {
            return _userRepository.ChangePassword(id, password);
        }

        public UserBO Check(UserBO entity)
        {
            return _userRepository.Check(entity.MapTo<User>()).MapTo<UserBO>();
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<UserBO> GetAll()
        {
            return _userRepository.GetAll().Select(u => u.MapTo<UserBO>());
        }

        public UserBO GetById(int id)
        {
            return _userRepository.GetById(id).MapTo<UserBO>();
        }

        public int Insert(UserBO entity)
        {
            SendActivationEmail(entity);
            return _userRepository.Insert(entity.MapTo<User>());
        }

        public bool Update(int id, UserBO entity)
        {
            User user = entity.MapTo<User>();
            user.Id = id;
            return _userRepository.Update(user);
        }
    
    
        private bool SendActivationEmail(UserBO entity)
        {
            using (MailMessage mm = new MailMessage("ra.gestion.entreprise@gmail.com", entity.Email))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + entity.FirstName + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = 'http://localhost:49895/user/ActivationCode=" + Guid.NewGuid().ToString()
                    //Request.Url.AbsoluteUri.Replace("CS.aspx", "CS_Activation.aspx?ActivationCode=" + Guid.NewGuid().ToString()) 
                    + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("ra.gestion.entreprise@gmail.com", "aqzsedrf0465");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                //smtp.Send(mm);

                try
                {
                    smtp.SendMailAsync(mm);
                }catch(Exception ex)
                {
                    return false;
                }

            }

            return true;
        }
    }
}
