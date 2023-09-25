using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Models;

namespace TibFinanceBusinessLayer.IService.IUserPermissions
{
    public interface IUserPermissions
    {
        UserPermission CreatePermission(UserPermission permission);
        void UpdatePermission(UserPermission permission);
        IEnumerable<UserPermission> GetAllPermission();
        UserPermission GetPermissionById(int permissionId);
        UserPermission DeletePermission(UserPermission role);

    }
}
