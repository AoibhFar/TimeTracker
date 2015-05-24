using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timeTracker.Domain;

namespace timeTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITimeTrackerDataSource _data;

        public HomeController(ITimeTrackerDataSource data)
      
        {
            _data = data;
        }
        public ActionResult Index()
        {
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var id = RouteData.Values["id"];
            //var message = String.Format("{0}::{1} {2}", controller, action, id);
            //ViewBag.Message = message;
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact");
        }

        protected override void Dispose(bool disposing)
        {
            _data.Dispose();
            base.Dispose(disposing);
        }

    }
}