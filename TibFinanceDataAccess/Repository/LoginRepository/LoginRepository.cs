using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Interface.Login;
using TibFinanceDataAccess.Models;
using TibFinance.Shared.ViewModels;

namespace TibFinanceDataAccess.Repository.LoginRepository
{
    public class LoginRepository : ILogin
    {
        private ApplicationDbContext db;
        public LoginRepository() 
        {             
        }
        public UserLogin LoginToDashBoard(string username, string password)
        {
            this.db = new ApplicationDbContext();
            UserLogin user = new UserLogin();

            user = db.Logins.Where(c => c.UserName == username && c.Password == password).FirstOrDefault();
            return user;
        }
    }
}
