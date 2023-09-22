using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Interface.Menus;
using TibFinanceDataAccess.Interface.Modules;
using TibFinanceDataAccess.Interface.Roles;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.MenusRepository;
using TibFinanceDataAccess.Repository.ModuleRepository;
using TibFinanceDataAccess.Repository.RolesRepository;

namespace TibFinanceBusinessLayer.Services.RoleServices
{
    public class RoleServices
    {
        private IRole roleRepository = null;
        //private IMenu _menuRepository = null;
        public RoleServices()
        {
            this.roleRepository = new RoleRepository();
           
        }
        public Role CreateRoles(Role role)
        {
            return roleRepository.Create(role);
        }
        public bool DeleteRole(int id)
        {
            try
            {
                var module = roleRepository.GetById(id);
                roleRepository.Delete(module);
                return true;
            }

            catch (Exception)
            {
                return false;
                throw;

            }
            //throw new NotImplementedException();
        }
        public  IEnumerable<Role> GetAllRoles()
        {
            try
            {
                return roleRepository.GetAll().ToList();
            }catch(Exception e) 
            {
                throw e;
            }
        }
        public Role GetRoleById(int? moduleId)
        {
            return roleRepository.GetById(moduleId);
            // var menu = _menuRepository.GetById(menuId);

            //  throw new NotImplementedException();
        }
        public void UpdateRole(Role role)
        {
            try
            {
               

                roleRepository.Update(role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }

    }
}
