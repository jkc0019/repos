using System;
using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers {

    public class HomeController : Controller {

		public ViewResult Index()
		{
			ViewBag.Message = "Heya";
			ViewBag.Time = DateTime.Now.ToShortTimeString();
			return View("DebugData");
		}

        public ViewResult List() => View();
    }
}
