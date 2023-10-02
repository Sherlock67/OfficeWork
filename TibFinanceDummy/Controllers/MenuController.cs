using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;
using TibFinanceBusinessLayer.Services.MenuServices;
using TibFinanceBusinessLayer.Services.ModuleServices;
using TibFinanceDataAccess;
using TibFinanceDataAccess.Models;

namespace TibFinanceDummy.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        private readonly MenuService menuService;
        private readonly ModuleService moduleService;
        public ApplicationDbContext db;
        public MenuController(MenuService menuService,ModuleService moduleService)
        {
            this.moduleService = moduleService;
            this.menuService = menuService;
        }
        public ActionResult Index()
        {
            var moduleList = moduleService.AllModulesDropDown().ToList();
            ViewBag.ListOfModule = new SelectList(moduleList, "ModuleId", "ModuleName");
            return View();
        }
        public JsonResult GetAllMenus(int? pageNumber ,int? pageSize)
        {
            var data = menuService.GetAllMenus(pageNumber,pageSize).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddOrEditMenu(Menu menus)
        {
            db = new ApplicationDbContext();
            Menu menu = db.Menus.Where(x => x.MenuId == menus.MenuId).FirstOrDefault();
            if (menu != null)
            {
                 menu.MenuName = menus.MenuName;
                 menu.MenuDescription = menus.MenuDescription;
                 menu.CreatedBy = menus.CreatedBy;
                 menu.UpdatedBy = menus.UpdatedBy;
                 menu.ModuleId = menus.ModuleId;
                 menuService.UpdateMenu(menus);
            }
            else
            {
                menus.MenuName = menus.MenuName;
                menus.CreatedBy = menus.CreatedBy;
                menus.UpdatedBy = menus.UpdatedBy;
                menus.MenuDescription = menus.MenuDescription;
                //menu.ModuleId= menus.ModuleId;
                menuService.CreateMenu(menus);
            }

            return Json(menus, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMenuId(int? MenuId)
        {
            var menuById = menuService.GetMenuById(MenuId);

            string value = string.Empty;
            value = JsonConvert.SerializeObject(menuById, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteMenu(int MenuId)
        {
            var menuToDelete = menuService.DeleteMenu(MenuId);
            return Json(menuToDelete, JsonRequestBehavior.AllowGet);

        }
    }
}