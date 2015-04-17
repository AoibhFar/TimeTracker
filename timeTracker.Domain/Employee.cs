using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Department { get; set; }
        public virtual string Role { get; set; }
        public virtual string Manager { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual int Rate { get; set; }

    }
}
