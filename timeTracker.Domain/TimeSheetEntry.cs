using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
    public class TimeSheetEntry
    {
        public virtual int Id { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual int Notes { get; set; }
        public virtual bool Billable { get; set; }
        public virtual string Day { get; set; }
        public virtual DateTime? Workdate { get; set; }
    }
    
}
