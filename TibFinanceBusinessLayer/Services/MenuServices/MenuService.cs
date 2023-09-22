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

namespace TibFinanceBusinessLayer.Services.MenuServices
{
    public class MenuService
    {
        private IMenu menuRepository = null;
        public MenuService() 
        {
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
        public IEnumerable<Menu> GetAllMenus()
        {
            try
            {
                return menuRepository.GetAll().ToList();
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
