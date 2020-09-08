using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(string login = null, string password = null)
               : base("account/", login, password)
        {
            //_uri = "user/";
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Post(Account entity)
        {
            throw new NotImplementedException();
        }

        public bool Put(int id, Account entity)
        {
            throw new NotImplementedException();
        }
    }
}