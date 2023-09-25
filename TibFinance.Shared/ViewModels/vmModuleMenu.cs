using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinance.Shared.ViewModels;

namespace TibFinanceShared.ViewModels
{
    public class vmModuleMenu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public List<vmModule> Modules { get; set; }
        public List<vmRole> Roles { get; set; }

    }
  
}
