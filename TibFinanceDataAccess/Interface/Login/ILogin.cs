using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Interface.Login
{
    public interface ILogin 
    {
        UserLogin LoginToDashBoard(string username, string password);
    }
}
