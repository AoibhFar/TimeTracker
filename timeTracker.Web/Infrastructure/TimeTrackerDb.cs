using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using timeTracker.Domain;
using timeTracker.Web.Models;

namespace timeTracker.Web.Infrastructure
{
    public class TimeTrackerDb : IdentityDbContext<ApplicationUser>, ITimeTrackerDataSource
    {
        public TimeTrackerDb() : base("DefaultConnection") { }

        public static TimeTrackerDb Create()
        {
            return new TimeTrackerDb();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<TimeSheetEntry> TimeSheetEntries { get; set; }

        void ITimeTrackerDataSource.Save()
        {
            SaveChanges();
        }

        // Methods for Company 

        void ITimeTrackerDataSource.addCompany(Company company)
        {
            Companies.Add(company);
        }

        void ITimeTrackerDataSource.deleteCompany(Company company) { }

        void ITimeTrackerDataSource.editCompany(Company company) { }

        // Methods for TimeSheet

        void ITimeTrackerDataSource.addTimeSheet(TimeSheet timesheet)
        {
            TimeSheets.Add(timesheet);

        }

        void ITimeTrackerDataSource.deleteTimeSheet(TimeSheet timesheet) { }

        void ITimeTrackerDataSource.editTimeSheet(TimeSheet timesheet) { }

        // Methods for TimeSheetEntry

        void ITimeTrackerDataSource.addTimeSheetEntry(TimeSheetEntry entry)
        {
            TimeSheetEntries.Add(entry);

        }

        void ITimeTrackerDataSource.deleteTimeSheetEntry(TimeSheetEntry entry) { }

        void ITimeTrackerDataSource.editTimeSheetEntry(TimeSheetEntry entry) { }


        IQueryable<Employee> ITimeTrackerDataSource.Employees
        {
            get { return Employees; }
        }

        IQueryable<Project> ITimeTrackerDataSource.Projects
        {
            get { return Projects; }
        }

        IQueryable<Company> ITimeTrackerDataSource.Companies
        {
            get { return Companies; }
        }

        IQueryable<TimeSheet> ITimeTrackerDataSource.TimeSheets
        {
            get { return TimeSheets; }
        }

        IQueryable<TimeSheetEntry> ITimeTrackerDataSource.TimeSheetEntries
        {
            get { return TimeSheetEntries; }
        }
    }
}