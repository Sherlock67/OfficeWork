using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TibFinanceBusinessLayer.Services.MenuServices;
using TibFinanceBusinessLayer.Services.ModuleServices;
using TibFinanceDataAccess;
using TibFinanceDataAccess.Models;

namespace TibFinanceDummy.Controllers
{
   
    public class ModuleController : Controller
    {
        private readonly ModuleService moduleService;
        private readonly MenuService menuService;
        private  ApplicationDbContext db;
        public ModuleController(ModuleService moduleService,MenuService menuService)
        {
            this.menuService = menuService;
            this.moduleService = moduleService;
        }
        // GET: Module
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public JsonResult AllModules(int? pageNumber, int? pageSize)
        {
           // var data1 = moduleService.GetAllModuleWithOutPaging();
            var data = moduleService.GetAllModule(pageNumber,pageSize).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public JsonResult AddOrEditModule(Module module)
        {
            db = new ApplicationDbContext();
            Module m = db.Modules.Where(x => x.ModuleId == module.ModuleId).FirstOrDefault();
            if(string.IsNullOrEmpty(module.ModuleName))
            {
                return Json(module, JsonRequestBehavior.AllowGet);
            }
            if (m!= null)
            {
                
                m.ModuleName = module.ModuleName;
                m.CreatedBy = module.CreatedBy;
                m.UpdatedBy = module.UpdatedBy;
                moduleService.UpdateModule(module);
            }
            else
            {
                module.ModuleName = module.ModuleName;
                module.CreatedBy = module.CreatedBy;
                module.UpdatedBy = module.UpdatedBy;
                moduleService.CreateModules(module);
            }
           
            return Json(module,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModuleId(int? ModuleId)
        {
            var moduleById = moduleService.GetModuleById(ModuleId);
           
            string value = string.Empty;
            value = JsonConvert.SerializeObject(moduleById, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteModule(int ModuleId)
        {
            var moduleToDelete = moduleService.DeleteModule(ModuleId);
            return Json(moduleToDelete,JsonRequestBehavior.AllowGet);
           
        }


    }
}