using System;
using System.Configuration;
using System.Web.Mvc;
using MusicStore.Logic.Utils;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Initer.Init(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);

            return View();
        }
    }
}