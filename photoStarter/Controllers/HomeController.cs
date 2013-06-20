using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
	}
}
