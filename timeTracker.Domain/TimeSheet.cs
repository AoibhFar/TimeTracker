using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
   public class TimeSheet
    {
        public virtual int Id { get; set;}
        public virtual int EmployeeId { get; set; }
        public virtual DateTime? WeekStarting { get; set; }
        public virtual ICollection<TimeSheetEntry> TimeSheetEntries { get; set; } 
    }

}
