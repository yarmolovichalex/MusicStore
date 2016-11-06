﻿using System.Linq;
using System.Web.Mvc;
using MusicStore.Logic.Artists;
using MusicStore.Logic.Business;
using MusicStore.Web.ViewModels;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;

        public HomeController(IArtistService artistService, IAlbumService albumService)
        {
            _artistService = artistService;
            _albumService = albumService;
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

        [HttpGet]
        public ActionResult GetAlbums()
        {
            var data = _albumService.GetAll();
            return Json(data.Select(x => new AlbumVm
            {
                Name = x.Name,
                ArtistName = x.ArtistName,
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