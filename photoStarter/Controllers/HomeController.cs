using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace photoStarter.Controllers {
	public class HomeController : Controller {
		public ActionResult Index(string userId) {
			var jimmy = userId;
			ViewBag.Title = "Home";
			ViewBag.Message = "My Photo's";

			return View(jimmy);
		}


		public ActionResult WordCloud() {
			ViewBag.Title = "WordCloud";
			ViewBag.Message = "Tag Word Cloud";

			return View();
		}

		public ActionResult AboutMe() {
			ViewBag.Title = "About Me";
			ViewBag.Message = "What d'ya wanna know?";

			return View();
		}
	}
}
