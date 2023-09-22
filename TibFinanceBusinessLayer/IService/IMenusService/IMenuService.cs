using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Models;

namespace TibFinanceBusinessLayer.IService.IMenusService
{
    public interface IMenuService
    {
        Menu CreateModule(Module module);
        void UpdateModule(Module module);
        IEnumerable<Menu> GetAllModule();
        Menu GetModuleById(int moduleId);
        Menu DeleteModule(Module module);
    }
}
