using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TibFinanceDataAccess.Interface.Menus;
using TibFinanceDataAccess.Models;

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

        public void Delete(int id)
        {
            this.db = new ApplicationDbContext();
            var menus = db.Menus.Where(x => x.MenuId == id).FirstOrDefault();
            if(menus != null)
            {
                db.Menus.Remove(menus);
                db.SaveChanges();
            }
          
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

        public IEnumerable<Menu> SearchByName(string name)
        {
            throw new NotImplementedException();
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
