using System.Web.Mvc;

namespace MusicStore.Web.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult AddEntity()
        {
            return View();
        }

        [HttpPost]
        public void AddArtist()
        {
            
        }

        [HttpPost]
        public void AddAlbum()
        {

        }

        [HttpPost]
        public void AddTrack()
        {
            
        }
    }
}