using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinance.Shared.ViewModels;
using TibFinanceBusinessLayer.Helper;
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
        public IEnumerable<vmModuleMenu> GetAllMenus(int? pageNumber,int? pageSize)
        {
            try
            {
                var paging = new vmCmnParameters()
                {
                    pageNumber = Convert.ToInt32(pageNumber == null ? 0 : pageNumber),
                    pageSize = Convert.ToInt32(pageSize == null ? 0 : pageSize)

                };
                var menus = menuRepository.GetAll().ToList();
                var modules = moduleRepository.GetAll().ToList();
                var totalData = modules.Count();
                var vmModuleMenuList = (from menu in menus
                                        join module in modules
                                              on menu.ModuleId equals module.ModuleId into modulemenu
                                        from modulemenus in modulemenu.DefaultIfEmpty()
                                        select new vmModuleMenu()
                                        {
                                            total = totalData,
                                            MenuName = menu.MenuName,
                                            ModuleId = Convert.ToInt32(modulemenus == null ? 0 : modulemenus.ModuleId),
                                            ModuleName = modulemenus == null ? "" : modulemenus.ModuleName,
                                            MenuDescription = menu.MenuDescription,
                                            CreatedBy = menu.CreatedBy,
                                            UpdatedBy = menu.UpdatedBy,
                                            MenuId = Convert.ToInt32(menu.MenuId),


                                        }).Skip(SkipOverload.Skip(paging)).Take((int)paging.pageSize).ToList();
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
