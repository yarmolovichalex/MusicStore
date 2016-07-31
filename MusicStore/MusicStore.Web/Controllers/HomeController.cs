using System.Linq;
using System.Web.Mvc;
using MusicStore.Logic.Artists;
using MusicStore.Web.ViewModels;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtistRepository _artistRepository;

        public HomeController()
        {
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
    }
}