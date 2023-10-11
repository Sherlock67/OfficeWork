using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TibFinanceDataAccess.Interface.Roles;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Repository.RolesRepository
{
    public class RoleRepository : IRole
    {
        private ApplicationDbContext db;
        public RoleRepository()
        {
                
        }
        public Role Create(Role entity)
        {
            db = new ApplicationDbContext();
            var obj = db.Roles.Add(entity);
            db.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            db = new ApplicationDbContext();
            var role = db.Roles.Where(x=>x.RoleId == id).FirstOrDefault();  
            if(role != null)
            {
                db.Roles.Remove(role);
                db.SaveChanges();

            }
           
            //throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            //db = new ApplicationDbContext();
            try
            {
                this.db = new ApplicationDbContext();
                return db.Roles.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Role GetById(int? Id)
        {
            db = new ApplicationDbContext();
           // this.db = new ApplicationDbContext();
            return db.Roles.Where(x => x.RoleId == Id).SingleOrDefault();
        }

        public IEnumerable<Role> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            db = new ApplicationDbContext();
            db.Roles.AddOrUpdate(entity);
            db.SaveChanges();
            // throw new NotImplementedException();
        }
    }
}
