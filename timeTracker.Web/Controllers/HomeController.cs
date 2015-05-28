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
            return View("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _data.Dispose();
            base.Dispose(disposing);
        }

    }
}