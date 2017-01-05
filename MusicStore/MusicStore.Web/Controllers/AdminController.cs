using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Logic.DTO.Album;
using MusicStore.Logic.DTO.Artist;
using MusicStore.Logic.DTO.Track;
using MusicStore.Logic.Model.Artist;
using MusicStore.Logic.Utils;
using MusicStore.Web.Helpers;
using MusicStore.Web.ViewModels.Admin;

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

        [HttpGet]
        public ActionResult GetArtists()
        {
            var data = _artistService.GetAll();
            return Json(data.Select(x => new ArtistVm
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SaveArtists(IEnumerable<EditArtistVm> artists)
        {
            _artistService.Save(artists.Select(x => new EditArtistDTO
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country
            }).ToList());
        }

        //[HttpPost]
        //public void AddAlbum(AlbumVm model)
        //{
        //    _albumService.AddAlbum(new AlbumDTO
        //    {
        //        ArtistName = model.ArtistName,
        //        Name = model.Name,
        //        Year = model.Year
        //        //Price = new MoneyDTO
        //        //{
        //        //    Amount = model.Price.Amount,
        //        //    Currency = model.Price.Currency
        //        //}
        //    });
        //}

        [HttpGet]
        public ActionResult PopulateDb()
        {
            var artist1 = new Artist("Metallica", "USA");
            var album1_1 = new AddAlbumDTO
            {
                Name = "Master Of Puppets",
                Year = 1986,
                CoverUrl = "https://lastfm-img2.akamaized.net/i/u/770x0/07f492a00c904cc6ccf868010be4d5a6.jpg",
                Tracks = new List<AddTrackDTO>
                {
                    new AddTrackDTO { Number = 1, Name = "Battery", Duration = DateHelper.GetSeconds(5, 13) },
                    new AddTrackDTO { Number = 2, Name = "Master of Puppets", Duration = DateHelper.GetSeconds(8, 35) },
                    new AddTrackDTO { Number = 3, Name = "The Thing That Should Not Be", Duration = DateHelper.GetSeconds(6, 36) },
                    new AddTrackDTO { Number = 4, Name = "Welcome Home (Sanitarium)", Duration = DateHelper.GetSeconds(6, 27) },
                    new AddTrackDTO { Number = 5, Name = "Disposable Heroes", Duration = DateHelper.GetSeconds(8, 17) },
                    new AddTrackDTO { Number = 6, Name = "Leper Messiah", Duration = DateHelper.GetSeconds(5, 40) },
                    new AddTrackDTO { Number = 7, Name = "Orion", Duration = DateHelper.GetSeconds(8, 27) },
                    new AddTrackDTO { Number = 8, Name = "Damage, Inc.", Duration = DateHelper.GetSeconds(5, 31) }
                }
            };

            var album1_2 = new AddAlbumDTO
            {
                Name = "Metallica",
                Year = 1991,
                CoverUrl = "https://lastfm-img2.akamaized.net/i/u/770x0/42073c53961041e0b028da2f157402b6.jpg",
                Tracks = new List<AddTrackDTO>
                {
                    new AddTrackDTO { Number = 1, Name = "Enter Sandman", Duration = DateHelper.GetSeconds(5, 32) },
                    new AddTrackDTO { Number = 2, Name = "Sad but True", Duration = DateHelper.GetSeconds(5, 25) },
                    new AddTrackDTO { Number = 3, Name = "Holier Than Thou", Duration = DateHelper.GetSeconds(3, 48) },
                    new AddTrackDTO { Number = 4, Name = "The Unforgiven", Duration = DateHelper.GetSeconds(6, 27) },
                    new AddTrackDTO { Number = 5, Name = "Wherever I May Roam", Duration = DateHelper.GetSeconds(6, 44) },
                    new AddTrackDTO { Number = 6, Name = "Don't Tread on Me", Duration = DateHelper.GetSeconds(4, 0) },
                    new AddTrackDTO { Number = 7, Name = "Through the Never", Duration = DateHelper.GetSeconds(4, 04) },
                    new AddTrackDTO { Number = 8, Name = "Nothing Else Matters", Duration = DateHelper.GetSeconds(6, 29) },
                    new AddTrackDTO { Number = 9, Name = "Of Wolf and Man", Duration = DateHelper.GetSeconds(4, 17) },
                    new AddTrackDTO { Number = 10, Name = "The God That Failed", Duration = DateHelper.GetSeconds(5, 9) },
                    new AddTrackDTO { Number = 11, Name = "My Friend of Misery", Duration = DateHelper.GetSeconds(6, 50) },
                    new AddTrackDTO { Number = 12, Name = "The Struggle Within", Duration = DateHelper.GetSeconds(3, 54) }
                }
            };

            artist1.AddAlbums(new List<AddAlbumDTO> { album1_1, album1_2 });

            var artist2 = new Artist("Slipknot", "USA");

            //artist2.AddAlbum(new Album("Iowa", artist2, 2001, new Money(6.0m, "USD")));
            //artist2.AddAlbum(new Album("Slipknot", artist2, 1999, new Money(6.0m, "USD")));

            var artist3 = new Artist("Rammstein", "Germany");
            //artist3.AddAlbum(new Album("Mutter", artist3, 2001, new Money(8.0m, "EUR")));
            //artist3.AddAlbum(new Album("Reise, Reise", artist3, 2004, new Money(8.0m, "EUR")));

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