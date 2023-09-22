using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TibFinanceDataAccess.Interface.Customers;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Repository.CustomerRepository
{
    public class CustomerRepository  : ICustomer
    {
        private readonly Model1 db;
        public CustomerRepository(Model1 db)
        {
            this.db = db;    
        }
        public  Customer Create(Customer entity)
        {
            var obj =  db.Customers.Add(entity);
            db.SaveChanges();
            return obj;      

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
        public Customer GetById(int? Id)
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
