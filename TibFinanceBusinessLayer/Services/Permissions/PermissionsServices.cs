using System;
using System.Collections.Generic;
using System.Linq;
using TibFinanceDataAccess.Interface.UserPermissions;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.UserPermissionRepository;

namespace TibFinanceBusinessLayer.Services.Permissions
{
    public class PermissionsServices
    {
        private IUserPermission permissionRepository;
        public PermissionsServices()
        {
            this.permissionRepository = new PermissionRepository();

        }
        public UserPermission CreateUserPermission(UserPermission permission)
        {
            return permissionRepository.Create(permission);

        }
        public bool DeleteUserPermission(int id)
        {
            try
            {
                var permission = permissionRepository.GetById(id);
                permissionRepository.Delete(permission);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public IEnumerable<UserPermission> GetUserPermission()
        {
            try
            {
                return permissionRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }
        public UserPermission GetPermissionById(int? permissionId)
        {
            return permissionRepository.GetById(permissionId);
        }
        public void UpdateUserPermission(UserPermission permission)
        {
            try
            {
                permissionRepository.Update(permission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
