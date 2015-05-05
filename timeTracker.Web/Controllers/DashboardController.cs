using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timeTracker.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnnualLeave
        public ActionResult AnnualLeave()
        {
            return View();
        }


        public JsonResult GetJsonData()
        {
            var data = new[] { new {Name = "Jane", Taken = 5}, 
            new {Name = "Damien", Taken = 6},
            new {Name = "Aoibheann", Taken = 3},
            new {Name = "Lisa", Taken = 2},
            new {Name = "Chris", Taken = 4},
            new {Name = "Lorna", Taken = 6} };

            return Json(data);
        }
    }
}