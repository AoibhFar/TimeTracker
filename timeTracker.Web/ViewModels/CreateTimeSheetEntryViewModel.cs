using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timeTracker.Web.ViewModels
{
    public class CreateTimeSheetEntryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int TimeSheetId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string OwnerId { get; set; }
        [Display(Name = "Employee")]
        public string OwnerName { get; set; }
        public int CompanyId { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public int ProjectId { get; set; }
        [Display(Name = "Project")]
        public string ProjectName { get; set; }
        public string Notes { get; set; }
        public bool Billable { get; set; }
        public string Day { get; set; }
        [Range(1, 8)]
        public int Hours { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime? Workdate { get; set; }

    }
}