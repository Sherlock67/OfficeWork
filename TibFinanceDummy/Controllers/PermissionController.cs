using System.Linq;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using TibFinanceBusinessLayer.IService.IUserServices;
using TibFinanceBusinessLayer.Services.ModuleServices;
using TibFinanceBusinessLayer.Services.Permissions;
using TibFinanceBusinessLayer.Services.RoleServices;
using TibFinanceBusinessLayer.Services.UserServices;
using TibFinanceDataAccess;
using TibFinanceDataAccess.Models;

namespace TibFinanceDummy.Controllers
{
    public class PermissionController : Controller
    {
        private readonly PermissionsServices permissionsServices;
        
        private ApplicationDbContext db;
        private readonly ModuleService moduleService;
        private readonly UserService userService;
        private readonly RoleServices roleServices;
        public PermissionController(PermissionsServices permissionsServices , RoleServices roleServices)
        {
            this.permissionsServices = permissionsServices;
            this.roleServices = roleServices;

        }
        // GET: Permission
        public ActionResult Index()
        {
           // var userList = userService.GetAllUsers();
           // ViewBag.ListOfUsers = new SelectList(userList, "UserId", "UserName");
            return View();
        }
        public JsonResult GetAllPermissions()
        {
           

            var data = permissionsServices.GetAllUserPermission();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        //public JsonResult AddOrEditUser(UserPermission permission)
        //{
        //    db = new ApplicationDbContext();
        //    UserPermission userpermission = db.UserPermissions.Where(x => x.PermissionId == permission.PermissionId).FirstOrDefault();
        //    if (userpermission != null)
        //    {
        //        //userpermission.IsDelete = true;

        //        userpermission.IsDelete = permission.IsDelete;
        //        userpermission.IsCreate = permission.IsCreate;
        //        userpermission.IsEdit = permission.IsEdit;
        //        userpermission.isGetAll = permission.isGetAll;
        //        permissionsServices.UpdateUserPermission(permission);
        //    }
        //    else
        //    {
        //        //user.UserName = user.UserName;
        //        //user.FullName = user.FullName;
        //        //user.Password = user.Password;
        //        //userService.CreateUser(user);
        //    }

        //    //return Json(user, JsonRequestBehavior.AllowGet);
        //}
    }
}