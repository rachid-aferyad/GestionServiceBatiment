using GestionServiceBatiment.API.Models.Account;
using GestionServiceBatiment.API.Models.Users;
using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionServiceBatiment.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User/5
        public DisplayUser Get(LoginViewModel model)
        {
            return _userService.Check(model.MapTo<UserBO>()).MapTo<DisplayUser>();
        }



    }
}
