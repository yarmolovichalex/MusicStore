﻿using System.Web.Mvc;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
    }
}