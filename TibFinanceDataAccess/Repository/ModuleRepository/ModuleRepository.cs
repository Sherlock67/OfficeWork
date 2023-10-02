using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TibFinance.Shared.ViewModels;
using TibFinanceDataAccess.Interface.Modules;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Repository.ModuleRepository
{
    public class ModuleRepository : IModule
    {
        private ApplicationDbContext db;
        public ModuleRepository()
        {
             
        }
        public Module Create(Module entity)
        {
            this.db = new ApplicationDbContext();
            var obj = db.Modules.Add(entity);
            db.SaveChanges();
            return obj;
            //throw new NotImplementedException();
        }

        public void Delete(Module entity)
        {
            this.db = new ApplicationDbContext();
            var module =   db.Modules.Where(x => x.ModuleId == entity.ModuleId).FirstOrDefault();
            db.Modules.Remove(module);
            db.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<Module> GetAll()
        {
            try
            {
                this.db = new ApplicationDbContext();
                return db.Modules.ToList();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Module GetById(int? Id)
        {
            this.db = new ApplicationDbContext();
            return db.Modules.Where(x => x.ModuleId == Id).FirstOrDefault();
            // throw new NotImplementedException();
        }

        public void Update(Module entity)
        {
            this.db = new ApplicationDbContext();
            db.Modules.AddOrUpdate(entity);
            db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
