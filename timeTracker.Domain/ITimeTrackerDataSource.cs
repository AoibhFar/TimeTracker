using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace timeTracker.Domain
{
    public interface ITimeTrackerDataSource : IDisposable
    {
        //IQueryable<Project> Projects { get; }
        //IQueryable<Company> Companies { get;}
        //IQueryable<TimeSheet> TimeSheets { get; }
        //IQueryable<TimeSheetEntry> TimeSheetEntries { get; }
       
        //void addCompany(Company company);
        //void deleteCompany(Company company);
        //void editCompany(Company company);

        //void addProject(Project project);
        //void deleteProject(Project project);
        //void editProject(Project project);


        //void addTimeSheet(TimeSheet timesheet);
        //void deleteTimeSheet(TimeSheet timesheet);
        //void editTimeSheet(TimeSheet timesheet);

        //void addTimeSheetEntry(TimeSheetEntry entry);
        //void deleteTimeSheetEntry(TimeSheetEntry entry);
        //void editTimeSheetEntry(TimeSheetEntry entry);
       
        //void Save();   

        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Save();
        
    }
}
