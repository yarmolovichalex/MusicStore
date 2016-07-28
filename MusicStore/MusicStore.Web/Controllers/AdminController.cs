using System.Web.Mvc;
using MusicStore.Logic.Artists;
using MusicStore.Web.ViewModels;

namespace MusicStore.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public AdminController()
        {
            _artistRepository = new ArtistRepository();
            _albumRepository = new AlbumRepository();
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
            var artist = _artistRepository.GetByName(model.ArtistName);
            var album = new Album(model.Name, artist, model.Year, null); // TODO add Price
            _albumRepository.Save(album);
        }

        [HttpPost]
        public void AddTrack(TrackVm model)
        {
            
        }
    }
}