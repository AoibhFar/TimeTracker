﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace timeTracker.Web.Models
{
    public class BarChartModel
    {
        [Key]
        public int id { get; set; }
        public string RoleTitle { get; set; }
        public string RateTitle { get; set; }
        public BarChart BarChartData { get; set; }
       
    }

    public class BarChart
    {
        public string Role { get; set; }
        public string Rate { get; set; }
    }
}