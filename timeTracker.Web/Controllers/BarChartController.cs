using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timeTracker.Web.Models;

namespace timeTracker.Web.Controllers
{
    public class BarChartController : Controller
    {
        // GET: BarChart
        public ActionResult Index()
        {
            BarChartModel BcModel = new BarChartModel();
            BcModel.RateTitle = "Rate";
            BcModel.RoleTitle = "Role";
            return View(BcModel);
        }

        public BarChart GetBarChartData()
        {
            BarChart chart = new BarChart();
            return chart;
        }

        public JsonResult GetBarJsonData()
        {
            var data = new[] { new {Role = "Junior Developer", Rate = 20},
            new {Role = "Senior Developer", Rate = 35},
            new {Role = "Junior Tester", Rate = 15},
            new {Role = "Senior Developer", Rate = 25},
            new {Role = "System Architect", Rate = 45},
            new {Role = "Consultant", Rate = 60} };

            return Json(data);
        }
    }
}