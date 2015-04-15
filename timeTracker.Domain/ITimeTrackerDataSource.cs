using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
    public interface ITimeTrackerDataSource
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Project> Projects { get; }
        IQueryable<Company> Companies { get;}
        IQueryable<TimeSheet> TimeSheets { get; }
        IQueryable<TimeSheetEntry> TimeSheetEntries { get; }
        void Save();
    }
}
