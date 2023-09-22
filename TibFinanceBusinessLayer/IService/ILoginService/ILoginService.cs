
using TibFinanceDataAccess.Models;
namespace TibFinanceBusinessLayer.IService.ILoginService
{
    public interface ILoginService
    {
        UserLogin GetUserLogin(string username, string password);
        
    }
}
