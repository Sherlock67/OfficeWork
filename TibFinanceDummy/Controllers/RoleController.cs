using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;
using TibFinanceBusinessLayer.Services.RoleServices;
using TibFinanceDataAccess;
using TibFinanceDataAccess.Models;

namespace TibFinanceDummy.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext db;
        private readonly RoleServices roleService;
        // GET: Role
        public RoleController(RoleServices roleService)
        {
            this.roleService = roleService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetUserRoles()
        {
            var data = roleService.GetAllRoles().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public JsonResult AddOrEditRole(Role roles)
        {
            db = new ApplicationDbContext();
            Role role = db.Roles.Where(x => x.RoleId == roles.RoleId).FirstOrDefault();
            if (role != null)
            {
                role.RoleName = roles.RoleName;

                roleService.UpdateRole(roles);
            }
            else
            {
                roles.RoleName = roles.RoleName;
                roleService.CreateRoles(roles);
            }

            return Json(roles, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRoleId(int? RoleId)
        {
            var roleById = roleService.GetRoleById(RoleId);

            string value = string.Empty;
            value = JsonConvert.SerializeObject(roleById, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteRole(int RoleId)
        {
            var roleToDelete = roleService.DeleteRole (RoleId);
            return Json(roleToDelete, JsonRequestBehavior.AllowGet);

        }
    }
}