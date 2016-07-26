using System.Web.Mvc;
using MusicStore.Logic.Artists;
using MusicStore.Web.ViewModels;

namespace MusicStore.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IArtistRepository _artistRepository;

        public AdminController()
        {
            _artistRepository = new ArtistRepository();
        }

        [HttpGet]
        public ActionResult AddEntity()
        {
            return View();
        }

        [HttpPost]
        public void AddArtist(ArtistVm model)
        {
            var artist = new Artist(model.Name, model.Country);
            _artistRepository.Save(artist);
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