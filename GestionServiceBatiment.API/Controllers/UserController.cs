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
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        public IEnumerable<DisplayUser> Get()
        {
            return _userService.GetAll().Select(u => u.MapTo<DisplayUser>());
        }

        // GET: api/User/5
        public DisplayUser Get(int id)
        {
            return _userService.GetById(id).MapTo<DisplayUser>();
        }

        // POST: api/User
        public HttpResponseMessage Post(CreateUserForm createUserForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                UserBO userBO = createUserForm.MapTo<UserBO>();
                userBO.Role = UserRole.USER_SIMPLE;
                _userService.Insert(userBO);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(int id, UpdateUserForm updateUserForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                _userService.Update(id, updateUserForm.MapTo<UserBO>());

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/User/5
        public HttpResponseMessage Delete(int id)
        {
            _userService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    

    }
}
