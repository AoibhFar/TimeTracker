using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual string Description { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime? Startdate { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime? Finishdate { get; set; }
    }         
}
