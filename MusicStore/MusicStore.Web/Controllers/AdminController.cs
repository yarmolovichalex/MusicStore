using System.Collections.Generic;
using System.Web.Mvc;
using MusicStore.Logic.Artists;
using MusicStore.Logic.Business;
using MusicStore.Logic.DTOs.Album;
using MusicStore.Logic.DTOs.Money;
using MusicStore.Logic.SharedKernel;
using MusicStore.Logic.Utils;
using MusicStore.Web.ViewModels;

namespace MusicStore.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;

        public AdminController(IArtistService artistService, IAlbumService albumService)
        {
            _artistService = artistService;
            _albumService = albumService;
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

        [HttpGet]
        public ActionResult PopulateDb()
        {
            var artist1 = new Artist("Metallica", "USA");
            artist1.AddAlbum(new Album("Master Of Puppets", artist1, 1986, new Money(10.0m, "USD")));
            artist1.AddAlbum(new Album("Metallica", artist1, 1991, new Money(8.0m, "USD")));

            var artist2 = new Artist("Slipknot", "USA");
            artist2.AddAlbum(new Album("Iowa", artist2, 2001, new Money(6.0m, "USD")));
            artist2.AddAlbum(new Album("Slipknot", artist2, 1999, new Money(6.0m, "USD")));

            var artist3 = new Artist("Rammstein", "Germany");
            artist3.AddAlbum(new Album("Mutter", artist3, 2001, new Money(8.0m, "EUR")));
            artist3.AddAlbum(new Album("Reise, Reise", artist3, 2004, new Money(8.0m, "EUR")));

            _artistService.Save(new List<Artist>
            {
                artist1,
                artist2,
                artist3
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult RefreshSchema()
        {
            Initer.RefreshSchema();
            return RedirectToAction("Index", "Home");
        }
    }
}