using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TibFinanceDataAccess.Interface.Users;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Repository.UserRepository
{
    public class UserRepository : IUser
    {
        private ApplicationDbContext db;
        public User Create(User entity)
        {
            db = new ApplicationDbContext();
            var obj = db.Users.Add(entity);
            db.SaveChanges();
            return obj;

        }

        public void Delete(int id)
        {
            db = new ApplicationDbContext();
            var entity = db.Users.Where(x => x.UserId == id).FirstOrDefault();
            if(entity != null)
            {
                db.Users.Remove(entity);
                db.SaveChanges();
            }
           
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                this.db = new ApplicationDbContext();
                return db.Users.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
          
           
        }

        public User GetById(int? Id)
        {
            db = new ApplicationDbContext();

            return db.Users.Where(x => x.UserId == Id).SingleOrDefault();
        }

        public IEnumerable<User> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            db = new ApplicationDbContext();
            db.Users.AddOrUpdate(entity);
            db.SaveChanges();

        }
    }
}
