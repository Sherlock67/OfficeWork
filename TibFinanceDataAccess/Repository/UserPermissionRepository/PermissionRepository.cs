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
            var obj = db.UserPermissions.Add(entity);
            db.SaveChanges();
            return obj;
           
        }

        public void Delete(UserPermission entity)
        {
            db = new ApplicationDbContext();
            db.UserPermissions.Remove(entity);
            db.SaveChanges();
           
        }

        public IEnumerable<UserPermission> GetAll()
        {
          
            try
            {
                this.db = new ApplicationDbContext();
                return db.UserPermissions.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }

        public UserPermission GetById(int? Id)
        {
            db = new ApplicationDbContext();
            return db.UserPermissions.Where(x => x.PermissionId == Id).SingleOrDefault();
            
        }

        public void Update(UserPermission entity)
        {
            db = new ApplicationDbContext();
            db.UserPermissions.AddOrUpdate(entity);
            db.SaveChanges();
           
        }
    }
}
