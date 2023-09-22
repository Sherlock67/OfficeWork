using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Delete(User entity)
        {
            db = new ApplicationDbContext();
            db.Users.Remove(entity);
            db.SaveChanges();
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

        public void Update(User entity)
        {
            db = new ApplicationDbContext();
            db.Users.AddOrUpdate(entity);
            db.SaveChanges();

        }
    }
}
