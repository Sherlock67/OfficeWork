using System;
using System.Collections.Generic;
using System.Linq;
using TibFinanceShared.ViewModels;
using TibFinanceDataAccess.Interface.Menus;
using TibFinanceDataAccess.Interface.Modules;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.MenusRepository;
using TibFinanceDataAccess.Repository.ModuleRepository;
using TibFinance.Shared.ViewModels;
using TibFinanceBusinessLayer.Helper;


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
                //var module = _moduleRepository.GetById(id);
                _moduleRepository.Delete(id);
                return true;
            }
            
            catch (Exception)
            {
                return false;
                throw;

            }
            //throw new NotImplementedException();
        }
        public IEnumerable<vmModuleMenu> AllModulesDropDown()
        {
            var moduleMenuDropDownList = _moduleRepository.GetAll();
            return (IEnumerable<vmModuleMenu>)moduleMenuDropDownList;
        }
        public IEnumerable<vmModuleMenu> GetAllModuleWithOutPaging()
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
                                            MenuName = modulemenus == null ? "" : modulemenus.MenuName,
                                            ModuleId = Convert.ToInt32(module == null ? 0 : module.ModuleId),
                                            ModuleName = module == null ? "" : module.ModuleName,
                                            CreatedBy = module == null ? "" : module.CreatedBy,
                                            UpdatedBy = module == null ? "" : module.UpdatedBy,
                                            MenuId = Convert.ToInt32(modulemenus == null ? 0 : modulemenus.MenuId),
                                        }).ToList();
                return vmModuleMenuList;

            }
            catch (Exception ex) { throw ex; }
        }
        public IEnumerable<vmModuleMenu> GetAllModule(int? pageNumber,int? pageSize)
        {
            try
            {
                var paging = new vmCmnParameters()
                {
                    pageNumber = Convert.ToInt32(pageNumber == null ? 0 :pageNumber),
                    pageSize = Convert.ToInt32(pageSize == null ? 0 : pageSize)

                };
                var menus = _menuRepository.GetAll().ToList();
                var modules = _moduleRepository.GetAll().ToList();
                var totalData = modules.Count();
                var vmModuleMenuList = (from module in modules
                                        join menu in menus
                                              on module.ModuleId equals menu.ModuleId into modulemenu
                                        from modulemenus in modulemenu.DefaultIfEmpty()
                                        select new vmModuleMenu()
                                        {
                                            total = totalData,
                                            MenuName = modulemenus == null ? "" : modulemenus.MenuName,
                                            ModuleId = Convert.ToInt32(module == null ? 0 : module.ModuleId),
                                            ModuleName = module == null ? "" : module.ModuleName,
                                            CreatedBy = module == null ? "" : module.CreatedBy,
                                            UpdatedBy = module == null ? "" : module.UpdatedBy,
                                            MenuId = Convert.ToInt32(modulemenus == null ? 0 : modulemenus.MenuId),

                                        }).Skip(SkipOverload.Skip(paging)).Take((int)paging.pageSize).ToList();
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
                Menu menu = new Menu();
                var singleModule = _moduleRepository.GetById(module.ModuleId);
                var singleMenu = _menuRepository.GetById(menu.MenuId);

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
