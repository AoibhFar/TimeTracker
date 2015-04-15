using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timeTracker.Web.ViewModels
{
    public class CreateEmployeeViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

        public string Role { get; set; }

        public string Manager { get; set; }

        public int Rate { get; set; }
    }
}