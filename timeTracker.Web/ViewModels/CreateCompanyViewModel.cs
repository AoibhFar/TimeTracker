using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timeTracker.Web.ViewModels
{
    public class CreateCompanyViewModel
    {

        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Contact Person")]
        public string Contactperson { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string Contactnumber { get; set; }

        [Display(Name = "Contact Email")]
        public string Contactemail { get; set; }

        [Display(Name = "Description of Company")]
        public string Description { get; set; }
    }
}