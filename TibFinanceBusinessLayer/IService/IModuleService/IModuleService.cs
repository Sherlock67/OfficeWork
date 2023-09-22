using System.Collections.Generic;
using TibFinanceDataAccess.Models;

namespace TibFinanceBusinessLayer.IService.IModuleService
{
    public interface IModuleService
    {
        Module CreateModule(Module module);
        void UpdateModule(Module module);
        IEnumerable<Module> GetAllModule();
        Module GetModuleById(int moduleId);
        Module DeleteModule(Module module);
    }
}
