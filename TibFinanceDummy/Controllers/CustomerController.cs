using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TibFinanceDataAccess.Repository;

namespace TibFinanceDummy.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository customerRepository;
        public CustomerController(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
            
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}