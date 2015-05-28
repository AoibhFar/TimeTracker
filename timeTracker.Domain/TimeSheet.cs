using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
   public class TimeSheet
    {
        public virtual int Id { get; set;}
        public virtual string OwnerId { get; set; }

        [Display(Name = "Employee")]
        public virtual string OwnerName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Week Starting")]
        public virtual DateTime? WeekStarting { get; set; }

        [Display(Name = "Hours")]
        [Range(1,40)]
        public virtual float WeeklyHours { get; set; }

       // Collection to hold daily timesheet entries
        [Display(Name ="Entries")]
        public virtual ICollection<TimeSheetEntry> TimeSheetEntries { get; set; } 
    }

}
