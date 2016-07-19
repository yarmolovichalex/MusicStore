using System.Web.Mvc;
using MusicStore.Web.ViewModels;

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
        public void AddArtist(ArtistVm model)
        {
            
        }

        [HttpPost]
        public void AddAlbum(AlbumVm model)
        {

        }

        [HttpPost]
        public void AddTrack(TrackVm model)
        {
            
        }
    }
}