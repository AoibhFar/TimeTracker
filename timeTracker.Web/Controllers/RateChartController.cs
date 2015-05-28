using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timeTracker.Web.Infrastructure;
using timeTracker.Web.Models;

namespace timeTracker.Web.Controllers
{
    public class RateChartController : Controller
    {
        private readonly TimeTrackerDb _data;

        public RateChartController()
      
        {
            _data = new TimeTrackerDb();
        }
       
        public ActionResult Index()
        {
          
            RateChartModel rateModel = new RateChartModel();
            rateModel.RateTitle = "Rate";
            rateModel.RoleTitle = "Role";
            return View(rateModel);
        }

        public RateChart GetChartData()
        {
            RateChart chart = new RateChart();
            return chart;
        }

        public JsonResult GetJsonData()
        {

            var data = new[] { 
            new {Role = "Junior Developer", Rate = 20},
            new {Role = "Senior Developer", Rate = 35},
            new {Role = "Junior Tester", Rate = 15},
            new {Role = "Senior Tester", Rate = 25},
            new {Role = "System Architect", Rate = 45},
            new {Role = "Consultant", Rate = 60} };

            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}