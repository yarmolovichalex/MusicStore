using System;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Logic.Model.Artist;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtistService _artistService;

        public HomeController(IArtistService artistService)
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
            return Json(data.Select(x => new
            {
                x.Id,
                x.Name,
                x.Country
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAlbumsOfArtist(Guid artistId)
        {
            var data = _artistService.GetAlbumsOfArtist(artistId);

            var result = new
            {
                data.ArtistId,
                data.ArtistName,
                Albums = data.Albums.Select(x => new
                {
                    x.Name,
                    x.Year,
                    x.CoverUrl,
                    Price = new
                    {
                        Amount = 10m,
                        Currency = "USD" // todo
                    },
                    Tracks = x.Tracks.Select(y => new
                    {
                        y.Number,
                        y.Name,
                        y.Duration
                    })
                })
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}