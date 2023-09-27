using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Threading;
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
        public bool CreatePermission(List<UserPermission> entity)
        {
            db = new ApplicationDbContext();
            var permissionList = new List<UserPermission>();
            foreach (var permissions in entity)
            {
                var p = new UserPermission()
                {
                    MenuId = permissions.MenuId,
                    ModuleId = permissions.ModuleId,
                    RoleId = permissions.RoleId,
                    IsCreate = true,
                    isGetAll = true,
                    IsDelete = true,
                    IsEdit = true,
                };
                permissionList.Add(p);
            }
            var obj = db.MenuPermissions.AddRange(permissionList);
            db.SaveChanges();
            return true;
           
        }

        public UserPermission Create(UserPermission entity)
        {
            throw new NotImplementedException();
        }

        //public List<UserPermission> CreatePermission(List<UserPermission> entity)
        //{
        //    db = new ApplicationDbContext();
        //    var obj = db.MenuPermissions.Add();
        //    db.SaveChanges();
        //    return obj;

        //}



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

        public bool CreateList(List<UserPermission> entity)
        {
            db = new ApplicationDbContext();
            var permissionList = new List<UserPermission>();
            foreach (var permissions in entity)
            {

                var permission = db.MenuPermissions.Where(x => x.PermissionId == permissions.PermissionId).FirstOrDefault();
                if (permission == null)
                {
                    if (permissions.MenuId == 0 || permissions.RoleId == 0 || permissions.ModuleId == 0)
                    {
                        break;
                    }
                    else
                    {
                        var p = new UserPermission()
                        {
                            MenuId = permissions.MenuId,
                            ModuleId = permissions.ModuleId,
                            RoleId = permissions.RoleId,
                            UserId = permissions.UserId,
                            IsCreate = true,
                            isGetAll = true,
                            IsDelete = true,
                            IsEdit = true,
                        };
                        permissionList.Add(p);
                    }
                }
                else
                { 
                        permission.MenuId = permissions.MenuId;
                        permission.ModuleId = permissions.ModuleId;
                        permission.RoleId = permissions.RoleId;
                        permission.UserId = permissions.UserId;
                        permission.IsCreate = true;
                        permission.isGetAll = true;
                        permission.IsDelete = true;
                        permission.IsEdit = true;
                }
            }
            var obj = db.MenuPermissions.AddRange(permissionList);
            db.SaveChanges();
            return true;
        }
    }
}
