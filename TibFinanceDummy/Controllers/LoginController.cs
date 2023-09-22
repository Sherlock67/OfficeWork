using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TibFinance.Shared.ViewModels;
using TibFinanceBusinessLayer.IService.ILoginService;
using TibFinanceBusinessLayer.Services.LoginService;

namespace TibFinanceDummy.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginServices _loginServices;

        public LoginController(LoginServices loginServices)
        {
            this._loginServices = loginServices;
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]

        public JsonResult UserLogin(TibFinanceDataAccess.Models.UserLogin user)
        {
            var userCredentialsSuccess = _loginServices.GetUserLogin(user.UserName,user.Password);
            if (userCredentialsSuccess.UserName != null)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
