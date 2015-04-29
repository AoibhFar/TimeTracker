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

        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<TimeSheetEntry> TimeSheetEntries { get; set; }

        IQueryable<T> ITimeTrackerDataSource.Query<T>()
        {
            return Set<T>();
        }

         void ITimeTrackerDataSource.Add<T>(T entity)
        {
             Set<T>().Add(entity);
            
        }

        void ITimeTrackerDataSource.Update<T>(T entity)
        {
            Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        void ITimeTrackerDataSource.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void ITimeTrackerDataSource.Save()
        {
            SaveChanges();
        }

    }
}