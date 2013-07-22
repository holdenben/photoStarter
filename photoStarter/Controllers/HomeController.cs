using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlickrNet;
using photoStarter.ServiceLayer;

namespace photoStarter.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			ViewBag.Title = "Home";
			ViewBag.Message = "My Photo's";

			return View();
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
