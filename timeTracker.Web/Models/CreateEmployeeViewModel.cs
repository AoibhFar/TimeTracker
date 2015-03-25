using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timeTracker.Web.Models
{
    public class CreateEmployeeViewModel
    {

        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [Required]
        public  string Name { get; set; }

        [Required]
        public string Department { get; set; }

        public string Role { get; set; }

        public string Manager { get; set; }
    }
}