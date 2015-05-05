using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
    public class TimeSheetEntry
    {
        public virtual int Id { get; set; }
        public virtual int TimeSheetId { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual string Notes { get; set; }
        public virtual bool Billable { get; set; }
        public virtual string Day { get; set; }
        public virtual int Hours { get; set; }

        [Display(Name = "Employee")]
        public virtual string OwnerName { get; set; }

        
        [Display(Name = "Company")]
        public virtual string CompanyName { get; set; }

       
        [Display(Name = "Project")]
        public virtual string ProjectName { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public virtual DateTime? Workdate { get; set; }
    }
    
}
