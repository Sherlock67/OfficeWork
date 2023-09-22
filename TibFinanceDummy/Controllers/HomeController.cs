using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TibFinanceDummy.Models;

namespace TibFinanceDummy.Controllers
{
    public class HomeController : Controller
    {
        //private readonly CustomerRepository customerRepository;
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public ActionResult CreateCustomer(CustomerModel customer)
        //{
        //    try
        //    {
        //        // var req = Request.Form.a
        //        var objCust = new Customer()
        //        {
        //            CustomerName=customer.CustomerName,
        //            Email=customer.Email,
        //            PhoneNumber=customer.PhoneNumber,
        //        }
        //        ;
        //          customerRepository.Create(objCust);
        //        // return View(customer);
        //    }
        //    catch (Exception ex) { throw ex; }
        //    return Json(customer, JsonRequestBehavior.AllowGet);

        //}
        //}

    }
}