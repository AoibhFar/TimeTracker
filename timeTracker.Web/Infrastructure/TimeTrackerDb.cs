using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using timeTracker.Domain;

namespace timeTracker.Web.Infrastructure
{
    public class TimeTrackerDb : DbContext, ITimeTrackerDataSource
    {
        public TimeTrackerDb() : base("DefaultConnection")
        {
            
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



        IQueryable<Employee> ITimeTrackerDataSource.Employees
        {
            get { return Employees; }
        }

        IQueryable<Project> ITimeTrackerDataSource.Projects
        {
            get {return Projects; }
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

        public System.Data.Entity.DbSet<timeTracker.Web.Models.CreateProjectViewModel> CreateProjectViewModels { get; set; }
        public System.Data.Entity.DbSet<timeTracker.Web.Models.CreateEmployeeViewModel> CreateEmployeeViewModels { get; set; }
        public System.Data.Entity.DbSet<timeTracker.Web.Models.CreateCompanyViewModel> CreateCompanyViewModels { get; set; }
        public System.Data.Entity.DbSet<timeTracker.Web.Models.CreateTimeSheetViewModel> CreateTimeSheetViewModels { get; set; }
        public System.Data.Entity.DbSet<timeTracker.Web.Models.CreateTimeSheetEntryViewModel> CreateTimeSheetEntryViewModels { get; set; }
    }
}