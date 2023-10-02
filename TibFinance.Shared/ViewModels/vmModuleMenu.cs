using System.Collections.Generic;
using TibFinance.Shared.ViewModels;

namespace TibFinanceShared.ViewModels
{
    public class vmModuleMenu
    {
        public int PermissionId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public List<vmModule> Modules { get; set; }
        public List<vmRole> Roles { get; set; }
        public List<vmMenu> Menus { get; set; }
        public int total { get; set; }

    }
  
}
