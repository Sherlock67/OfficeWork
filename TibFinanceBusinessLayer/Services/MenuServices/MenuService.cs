using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Interface.Menus;
using TibFinanceDataAccess.Interface.Modules;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.MenusRepository;
using TibFinanceDataAccess.Repository.ModuleRepository;
using TibFinanceShared.ViewModels;

namespace TibFinanceBusinessLayer.Services.MenuServices
{
    public class MenuService
    {
        private IMenu menuRepository = null;
        private IModule moduleRepository = null;
        public MenuService() 
        {
            moduleRepository = new ModuleRepository();
            menuRepository = new MenuRepository();
        }
        public Menu CreateMenu(Menu module)
        {
            return menuRepository.Create(module);
            //throw new NotImplementedException();
        }
        public bool DeleteMenu(int id)
        {
            try
            {
                var module = menuRepository.GetById(id);
                menuRepository.Delete(module);
                return true;
            }

            catch (Exception)
            {
                return false;
                throw;

            }
            //throw new NotImplementedException();
        }
        public IEnumerable<vmModuleMenu> GetAllMenus()
        {
            try
            {
                var menus = menuRepository.GetAll().ToList();
                var modules = moduleRepository.GetAll().ToList();
                var vmModuleMenuList = (from module in modules
                                        join menu in menus
                                              on module.ModuleId equals menu.ModuleId into modulemenu
                                        from modulemenus in modulemenu.DefaultIfEmpty()
                                        select new vmModuleMenu()
                                        {
                                            MenuName = modulemenus.MenuName,
                                            ModuleId = modulemenus.ModuleId,
                                            ModuleName = module.ModuleName,
                                            MenuDescription = modulemenus.MenuDescription,
                                            CreatedBy = modulemenus.CreatedBy,
                                            UpdatedBy = modulemenus.UpdatedBy,
                                            MenuId = modulemenus.MenuId,


                                        }).ToList();
                return vmModuleMenuList;
              //  return menuRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }
        public Menu GetMenuById(int? menuId)
        {
            return menuRepository.GetById(menuId);
            //  throw new NotImplementedException();
        }
        public void UpdateMenu(Menu menu)
        {
            try
            {
                menuRepository.Update(menu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }

    }
}
