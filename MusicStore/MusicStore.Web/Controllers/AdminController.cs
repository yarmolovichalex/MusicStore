using System.Web.Mvc;
using MusicStore.Logic.Artists;
using MusicStore.Logic.Business;
using MusicStore.Logic.DTOs.Album;
using MusicStore.Logic.DTOs.Money;
using MusicStore.Web.ViewModels;

namespace MusicStore.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IArtistService _artistService;

        public AdminController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void AddArtist(ArtistVm model)
        {
            var artist = new Artist(model.Name, model.Country);
            _artistService.Save(artist);
        }

        [HttpPost]
        public void AddAlbum(AlbumVm model)
        {
            _artistService.AddAlbum(new AddAlbumDTO
            {
                ArtistName = model.ArtistName,
                Name = model.Name,
                Year = model.Year,
                Price = new MoneyDTO
                {
                    Amount = model.Price.Amount,
                    Currency = model.Price.Currency
                }
            });
        }

        [HttpPost]
        public void AddTrack(TrackVm model)
        {
            
        }
    }
}