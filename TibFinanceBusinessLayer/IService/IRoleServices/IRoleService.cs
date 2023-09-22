using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Models;

namespace TibFinanceBusinessLayer.IService.IRoleServices
{
    public interface IRoleService
    {
        Role CreateRole(Role role);
        void UpdateRole(Role role);
        IEnumerable<Role> GetAllRole();
        Role GetRoleById(int roleId);
        Role DeleteRole(Role role);
    }
}
