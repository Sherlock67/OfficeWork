using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TibFinanceDataAccess.Interface.Menus;
using TibFinanceDataAccess.Models;
using TibFinanceShared.ViewModels;

namespace TibFinanceDataAccess.Repository.MenusRepository
{
    public class MenuRepository : IMenu
    {
        private ApplicationDbContext db;
        public MenuRepository()
        {

        }
        public Menu Create(Menu entity)
        {
            this.db = new ApplicationDbContext();
            var obj = db.Menus.Add(entity);
            db.SaveChanges();
            return obj;
        }

        public void Delete(Menu entity)
        {
            this.db = new ApplicationDbContext();
            db.Menus.Remove(entity);
            db.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAll()
        {
            try
            {
                this.db = new ApplicationDbContext();
                return db.Menus.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Menu GetById(int? Id)
        {
            this.db = new ApplicationDbContext();
            return db.Menus.Where(x => x.MenuId == Id).SingleOrDefault();
        }

        public void Update(Menu entity)
        {
            this.db = new ApplicationDbContext();
            db.Menus.AddOrUpdate(entity);
            db.SaveChanges();
            // throw new NotImplementedException();
        }
    }
}
