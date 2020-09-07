using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return _userRepository.Insert(entity.MapTo<User>());
        }

        public bool Update(int id, UserBO entity)
        {
            User user = entity.MapTo<User>();
            user.Id = id;
            return _userRepository.Update(user);
        }
    }
}
