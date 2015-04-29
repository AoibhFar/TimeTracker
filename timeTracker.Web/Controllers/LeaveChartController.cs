using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timeTracker.Web.Models;

namespace timeTracker.Web.Controllers
{
    public class LeaveChartController : Controller
    {
        // GET: BarChart
        public ActionResult Index()
        {
          
            LeaveChartModel BcModel = new LeaveChartModel();
            BcModel.RateTitle = "Rate";
            BcModel.RoleTitle = "Role";
            return View(BcModel);
        }

        public BarChart GetLeaveChartData()
        {
            BarChart chart = new BarChart();
            return chart;
        }

        public JsonResult GetJsonData()
        {

            var data = new[] { 
            new {Role = "Junior Developer", Rate = 20},
            new {Role = "Senior Developer", Rate = 35},
            new {Role = "Junior Tester", Rate = 15},
            new {Role = "Senior Developer", Rate = 25},
            new {Role = "System Architect", Rate = 45},
            new {Role = "Consultant", Rate = 60} };

            return Json(data);
        }
    }
}