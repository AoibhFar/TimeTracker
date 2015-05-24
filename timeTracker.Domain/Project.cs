using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
    public class Project
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Company { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public virtual DateTime? Startdate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Finish Date")]
        public virtual DateTime? Finishdate { get; set; }
        [Display(Name = "Expected Man Hours")]
        public virtual int ExpectedHours { get; set; }
        public virtual int ActualHours { get; set;}
    }         
}
