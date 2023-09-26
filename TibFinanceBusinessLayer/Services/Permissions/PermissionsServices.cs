using System;
using System.Collections.Generic;
using System.Linq;
using TibFinance.Shared.ViewModels;
using TibFinanceDataAccess.Interface.Menus;
using TibFinanceDataAccess.Interface.Modules;
using TibFinanceDataAccess.Interface.Roles;
using TibFinanceDataAccess.Interface.UserPermissions;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.MenusRepository;
using TibFinanceDataAccess.Repository.ModuleRepository;
using TibFinanceDataAccess.Repository.RolesRepository;
using TibFinanceDataAccess.Repository.UserPermissionRepository;
using TibFinanceShared.ViewModels;

namespace TibFinanceBusinessLayer.Services.Permissions
{
    public class PermissionsServices
    {
        private IUserPermission permissionRepository;
        private IModule moduleRepository;
        private IMenu menuRepository;
        private IRole roleRepository;
        //private IUserPermission permissionRepository;
        public PermissionsServices()
        {
            this.menuRepository = new MenuRepository();
            this.moduleRepository = new ModuleRepository();
            this.roleRepository = new RoleRepository();
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
        public IEnumerable<vmModuleMenu> GetAllUserPermission()
        {
            try
            {   var modules = moduleRepository.GetAll();
                var roles = roleRepository.GetAll();
                var menus = menuRepository.GetAll();
                var permissions = permissionRepository.GetAll().ToList();
                var allPermission = (from module in modules
                                     join menu in menus on module.ModuleId equals menu.ModuleId into modulemenus
                                     from modulemenu in modulemenus.DefaultIfEmpty()
                                     join permission in permissions on
                                     new { moduleId = Convert.ToInt32(module.ModuleId), menuId = Convert.ToInt32(modulemenu.MenuId) } equals
                                     new { moduleId = Convert.ToInt32(permission==null?0:permission.ModuleId), menuId = Convert.ToInt32(permission==null?0:permission.MenuId) }
                                     into permList from p in permList.DefaultIfEmpty()
                                     select new vmModuleMenu
                                     {

                                         ModuleId = module.ModuleId,
                                         ModuleName = module.ModuleName,
                                         MenuDescription = modulemenu.MenuDescription,
                                         MenuName = modulemenu.MenuName,
                                         MenuId = modulemenu.MenuId,
                                         RoleId = Convert.ToInt32(p==null?0:p.RoleId),
                                         
                                         Roles = roles.Select(x => new vmRole { RoleId = x.RoleId, RoleName = x.RoleName }).ToList(),
                                         Modules = modules.Select(x => new vmModule { ModuleId = x.ModuleId, ModuleName = x.ModuleName }).ToList(),
                                         Menus = menus.Select(x => new vmMenu { MenuId = x.MenuId, MenuName = x.MenuName }).ToList()


                                     }).ToList();
                return allPermission;


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
