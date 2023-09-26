using System.Linq;
using System.Web.Mvc;
using TibFinanceBusinessLayer.Services.MenuServices;
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
        private readonly MenuService menuService;
        public PermissionController(PermissionsServices permissionsServices , RoleServices roleServices,MenuService menuService)
        {
            this.permissionsServices = permissionsServices;
            this.roleServices = roleServices;
            this.menuService = menuService;
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
        public JsonResult PermissionEdit(UserPermission userPermission)
        {
            db = new ApplicationDbContext();
            UserPermission uPermission = db.MenuPermissions.Where(x => x.PermissionId == userPermission.PermissionId).FirstOrDefault();
            if (uPermission != null)
            {
                uPermission.PermissionId = userPermission.PermissionId;
                uPermission.MenuId = userPermission.MenuId;
                uPermission.ModuleId = userPermission.ModuleId;
                uPermission.RoleId = userPermission.RoleId;
                permissionsServices.UpdateUserPermission(userPermission);
            }
            else
            {
                userPermission.PermissionId = userPermission.PermissionId;
                userPermission.MenuId = userPermission.MenuId;
                userPermission.ModuleId = userPermission.ModuleId;
                userPermission.RoleId= userPermission.RoleId;
                permissionsServices.CreateUserPermission(userPermission);
            }
            return Json(userPermission, JsonRequestBehavior.AllowGet);

        }
    }
}