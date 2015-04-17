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
    //public class TimeTrackerDb : DbContext, ITimeTrackerDataSource
    public class TimeTrackerDb : IdentityDbContext<ApplicationUser>, ITimeTrackerDataSource
    {
        public TimeTrackerDb() : base("DefaultConnection")
        {
            
        }

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

        public System.Data.Entity.DbSet<timeTracker.Web.Models.BarChartModel> BarChartModels { get; set; }

        //public System.Data.Entity.DbSet<timeTracker.Web.ViewModels.CreateEmployeeViewModel> CreateEmployeeViewModels { get; set; }
        //public System.Data.Entity.DbSet<timeTracker.Web.ViewModels.CreateProjectViewModel> CreateProjectViewModels { get; set; }
        //public System.Data.Entity.DbSet<timeTracker.Web.ViewModels.CreateEmployeeViewModel> CreateEmployeeViewModels { get; set; }
        //public System.Data.Entity.DbSet<timeTracker.Web.ViewModels.CreateCompanyViewModel> CreateCompanyViewModels { get; set; }
        //public System.Data.Entity.DbSet<timeTracker.Web.ViewModels.CreateTimeSheetViewModel> CreateTimeSheetViewModels { get; set; }
        //public System.Data.Entity.DbSet<timeTracker.Web.ViewModels.CreateTimeSheetEntryViewModel> CreateTimeSheetEntryViewModels { get; set; }

        
    }
}