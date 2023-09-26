using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibFinanceDataAccess.Models
{
    public class UserPermission
    {
        [Key]
        public int PermissionId { get; set; }
        public int ModuleId { get; set; }
        public string RoutingPath { get; set; }
        public string ModuleName { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; } 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsEdit { get; set; }    
       // public bool IsAdd { get; set; }
        public bool isGetAll { get; set; }
        public bool IsDelete { get; set; }
        public bool IsCreate { get; set; }
    }
}
