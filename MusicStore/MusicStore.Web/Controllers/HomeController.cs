using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Logic.Model.Artist;
using MusicStore.Web.ViewModels;

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
            return Json(data.Select(x => new ArtistVm
            {
                Name = x.Name,
                Country = x.Country
            }), JsonRequestBehavior.AllowGet);
        }
    }
}