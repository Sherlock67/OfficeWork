using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using TibFinanceBusinessLayer.IService.IUserServices;
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
        public PermissionController(PermissionsServices permissionsServices)
        {
            this.permissionsServices = permissionsServices;
        }
        // GET: Permission
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllPermissions()
        {
            var data = permissionsServices.GetAllUserPermission();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public JsonResult AddOrEditUser(UserPermission permission)
        {
            db = new ApplicationDbContext();
            UserPermission userpermission = db.UserPermissions.Where(x => x.PermissionId == permission.PermissionId).FirstOrDefault();
            if (userpermission != null)
            {
                userpermission.IsDelete = true;

                userpermission.IsDelete = permission.IsDelete;
                userpermission.IsCreate = permission.IsCreate;
                userpermission.
                permissionsServices.UpdateUserPermission(permission);
            }
            else
            {
                //user.UserName = user.UserName;
                //user.FullName = user.FullName;
                //user.Password = user.Password;
                //userService.CreateUser(user);
            }

            //return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}