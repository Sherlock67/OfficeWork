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
    }
}
