using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;
using TibFinanceBusinessLayer.IService.IMenusService;
using TibFinanceBusinessLayer.Services.ArtistServices;
using TibFinanceBusinessLayer.Services.MenuServices;
using TibFinanceDataAccess;
using TibFinanceDataAccess.Models;

namespace TibFinanceDummy.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ArtistService artistService;
        
        public ApplicationDbContext db;
        public ArtistController(ArtistService artistService)
        {
            this.artistService = artistService;
            
            
        }
        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetArtistByName(string artistName)
        {
            if(string.IsNullOrEmpty(artistName))
            {
                var data = artistService.GetAllArtistInfo().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var data = artistService.GetAllArtistByName(artistName);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddOrEditArtist(Artist artists)
        {
            db = new ApplicationDbContext();
            Artist artist = db.Artists.Where(x => x.ArtistId == artists.ArtistId).FirstOrDefault();
            if (artist != null)
            {
                artist.ArtistId = artists.ArtistId;
                artist.ArtistName = artists.ArtistName; 
                artistService.UpdateArtist(artists);
            }
            else
            {
                artists.ArtistId = artists.ArtistId;
                artists.ArtistName = artists.ArtistName;
                artistService.CreateArtist(artists);
            }

            return Json(artists, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetArtistId(int? ArtistId)
        {
            var artistById = artistService.GetArtistById(ArtistId);

            string value = string.Empty;
            value = JsonConvert.SerializeObject(artistById, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteArtist(int ArtistId)
        {
            var menuToDelete = artistService.DeleteArtist(ArtistId);
            return Json(menuToDelete, JsonRequestBehavior.AllowGet);

        }

    }
}