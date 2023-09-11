using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TibFinanceDummy.Models;

namespace TibFinanceDummy.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        tibfinancedummydbEntities4 db = new tibfinancedummydbEntities4();
        public ActionResult Index()
        {
            return View();
        }
        
    }
}