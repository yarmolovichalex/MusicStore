using System.Linq;
using System.Web.Mvc;
using MusicStore.Logic.Artists;
using MusicStore.Web.ViewModels;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public HomeController()
        {
            _albumRepository = new AlbumRepository();
            _artistRepository = new ArtistRepository();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetArtists()
        {
            var data = _artistRepository.GetAll();
            return Json(data.Select(x => new ArtistVm
            {
                Name = x.Name,
                Country = x.Country
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAlbums()
        {
            var data = _albumRepository.GetAll();
            return Json(data.Select(x => new AlbumVm
            {
                Name = x.Name,
                ArtistName = _artistRepository.GetById(x.Artist.Id).Name, // TODO Optimize
                Year = x.Year,
                Price = new MoneyVm
                {
                    Amount = x.Price.Amount,
                    Currency = x.Price.Currency
                }
            }), JsonRequestBehavior.AllowGet);
        }
    }
}