using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timeTracker.Web.ViewModels
{
    public class CreateTimeSheetViewModel
    {
       
        
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string OwnerId { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public string OwnerName { get; set; }

        [Display(Name = "Weekly Hours")]
        [Range (1,40)]
        public float WeeklyHours { get; set; }

        [Display(Name = "Week Starting")]
        [DataType(DataType.Date)]
        public DateTime? WeekStarting { get; set; }

       
    }
}