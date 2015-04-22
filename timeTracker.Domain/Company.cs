using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
   public  class Company
    {
       public virtual int Id { get; set; }
       public virtual string Name { get; set; }
       public virtual string Contactperson { get; set; }
       [Display(Name = "Contact Number")]
       public virtual string Contactnumber { get; set; }
       [Display(Name = "Contact Email")]
       public virtual string Contactemail { get; set; }
       public virtual string Description { get; set; }
       public virtual ICollection<Project> Projects { get; set; }
    }
}
