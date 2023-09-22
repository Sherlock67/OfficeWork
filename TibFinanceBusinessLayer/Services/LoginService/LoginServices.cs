using TibFinanceBusinessLayer.IService.ILoginService;
using TibFinanceDataAccess.Interface.Login;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.LoginRepository;
using TibFinance.Shared.ViewModels;
namespace TibFinanceBusinessLayer.Services.LoginService
{
    public class LoginServices : ILoginService
    {
        private ILogin _loginRepository = null;
        public LoginServices()
        {
            this._loginRepository = new LoginRepository();

        }
        public UserLogin GetUserLogin(string username, string password)
        {
            UserLogin userLogin = new UserLogin();
            userLogin = _loginRepository.LoginToDashBoard(username, password);
            return userLogin;

        }

    }
}
