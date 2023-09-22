using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Models;

namespace TibFinanceBusinessLayer.IService.IUserServices
{
    public interface IUserService
    {
        User CreateUser(User user);
        void UpdateRole(User user);
        IEnumerable<User> GetAllRole();
        User GetRoleById(int userId);
        User DeleteRole(User user);
    }
}
