using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Interface.Customers;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext db;
        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;    
        }
        public Customer Create(Customer entity)
        {
            var obj =  db.Customers.Add(entity);
            db.SaveChanges();
            return obj;
            //throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            db.Customers.Remove(entity);
            db.SaveChanges();
            
        }
        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return db.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer GetById(int Id)
        {
            return db.Customers.Where(x => x.CustomerId == Id).SingleOrDefault();
        }

        public void Update(Customer entity)
        {
            db.Customers.AddOrUpdate(entity);
            db.SaveChanges();
            
        }
    }
}
