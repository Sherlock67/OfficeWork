using System;
using System.Collections.Generic;
using System.Linq;
using TibFinance.Shared.ViewModels;
using TibFinanceDataAccess.Interface.Menus;
using TibFinanceDataAccess.Interface.Modules;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.MenusRepository;
using TibFinanceDataAccess.Repository.ModuleRepository;

namespace TibFinanceBusinessLayer.Services.ModuleServices
{
    public class ModuleService 
    {
        private IModule _moduleRepository = null;
        private IMenu _menuRepository = null;
        //private ApplicationDbContext db;
        public ModuleService()
        {
            this._moduleRepository = new ModuleRepository();
            this._menuRepository = new MenuRepository();

        }
        public Module CreateModules(Module module)
        {
            return _moduleRepository.Create(module);
            //throw new NotImplementedException();
        }

        public bool DeleteModule(int id)
        {
            try
            {
                var module = _moduleRepository.GetById(id);
                _moduleRepository.Delete(module);
                return true;
            }
            
            catch (Exception)
            {
                return false;
                throw;

            }
            //throw new NotImplementedException();
        }

        public IEnumerable<vmModuleMenu> GetAllModule()
        {
            try
            {
                var menus = _menuRepository.GetAll().ToList();
                var modules = _moduleRepository.GetAll().ToList();
                var vmModuleMenuList = (from module in modules
                                        join menu in menus
                                              on module.ModuleId equals menu.ModuleId into modulemenu
                                        from modulemenus in modulemenu.DefaultIfEmpty()
                                        select new vmModuleMenu()
                                        {
                                            MenuName = modulemenus.MenuName,
                                            ModuleId = modulemenus.ModuleId,
                                            ModuleName = modulemenus.MenuDescription,
                                            CreatedBy = modulemenus.CreatedBy,
                                            UpdatedBy = modulemenus.UpdatedBy,
                                            MenuId = modulemenus.MenuId,

                                        }).ToList();
                return vmModuleMenuList;

            }
            catch(Exception ex)
            {
                throw ex;
            }
          // throw new NotImplementedException();
        }

        public Module GetModuleById(int? moduleId)
        {
          return _moduleRepository.GetById(moduleId);
           // var menu = _menuRepository.GetById(menuId);

          //  throw new NotImplementedException();
        }
       
        public void UpdateModule(Module module)
        {
            try
            {
               
                _moduleRepository.Update(module);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            // throw new NotImplementedException();
        }
    }
}
