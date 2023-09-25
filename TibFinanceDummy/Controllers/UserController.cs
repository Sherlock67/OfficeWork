using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;
using TibFinanceBusinessLayer.Services.RoleServices;
using TibFinanceBusinessLayer.Services.UserServices;
using TibFinanceDataAccess;
using TibFinanceDataAccess.Models;

namespace TibFinanceDummy.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private readonly UserService userService;
        private readonly RoleServices roleService;
        private ApplicationDbContext db;
        public UserController(UserService userService,RoleServices roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }
        public ActionResult Index()
        {
            var roleList = roleService.GetAllRoles();
            ViewBag.ListOfRole = new SelectList(roleList, "RoleId", "RoleName");
            return View();
        }
        public JsonResult GetAllUser()
        {
            var data = userService.GetAllUsers().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public JsonResult AddOrEditUser(User user)
        {
            db = new ApplicationDbContext();
            User u = db.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (u != null)
            {

                u.UserName = user.UserName;
                u.FullName = user.FullName;
                u.Password = user.Password;
                userService.UpdateUser(user);
            }
            else
            {
                user.UserName = user.UserName;
                user.FullName = user.FullName;
                user.Password = user.Password;
                userService.CreateUser(user);
            }

            return Json(user, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserId(int? UserId)
        {
            var userById = userService.GetUserById(UserId);

            string value = string.Empty;
            value = JsonConvert.SerializeObject(userById, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteUser(int UserId)
        {
            var userToDelete = userService.DeleteUser(UserId);
            return Json(userToDelete, JsonRequestBehavior.AllowGet);

        }
    }
}