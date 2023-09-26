using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TibFinanceDataAccess.Interface.UserPermissions;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Repository.UserPermissionRepository
{
    public class PermissionRepository : IUserPermission
    {
        private ApplicationDbContext db;
        public PermissionRepository()
        {

        }
        public UserPermission Create(UserPermission entity)
        {
            db = new ApplicationDbContext();
            var obj = db.MenuPermissions.Add(entity);
            db.SaveChanges();
            return obj;
           
        }

        public void Delete(UserPermission entity)
        {
            db = new ApplicationDbContext();
            db.MenuPermissions.Remove(entity);
            db.SaveChanges();
           
        }

        public IEnumerable<UserPermission> GetAll()
        {
          
            try
            {
                this.db = new ApplicationDbContext();
                return db.MenuPermissions.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }

        public UserPermission GetById(int? Id)
        {
            db = new ApplicationDbContext();
            return db.MenuPermissions.Where(x => x.PermissionId == Id).SingleOrDefault();
            
        }

        public void Update(UserPermission entity)
        {
            db = new ApplicationDbContext();
            db.MenuPermissions.AddOrUpdate(entity);
            db.SaveChanges();
           
        }
    }
}
