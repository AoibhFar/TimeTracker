using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace timeTracker.Web.Models
{
    public class AnnualLeaveChartModel
    {

        public string NameTitle { get; set; }

        public string TakenTitle { get; set; }

        public string AvailableTitle { get; set; }

        public string Userid { get; set; }

        public string Name { get; set; }
        public int DaysTaken { get; set; }
        public int DaysAvailable { get; set; }

        public string Taken { get; set; }
        public string Available { get; set; }
    }
}





