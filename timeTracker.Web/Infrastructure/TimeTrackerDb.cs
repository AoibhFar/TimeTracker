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


        //// Methods for Company 

        //void ITimeTrackerDataSource.addCompany(Company company)
        //{
        //    Companies.Add(company);
        //}

        //void ITimeTrackerDataSource.deleteCompany(Company company) 
        //{
        //    Companies.Remove(company);
        //}

        //void ITimeTrackerDataSource.editCompany(Company company) 
        //{

        //    Entry(company).State = EntityState.Modified;
        //}

        //// Methods for Project

        //void ITimeTrackerDataSource.addProject(Project project)
        //{
        //    Projects.Add(project);
        //}

        //void ITimeTrackerDataSource.deleteProject(Project project) 
        //{
        //    Projects.Remove(project);
        //}

        //void ITimeTrackerDataSource.editProject(Project project) 
        //{
        //    Entry(project).State = EntityState.Modified;
        //}

        //// Methods for TimeSheet

        //void ITimeTrackerDataSource.addTimeSheet(TimeSheet timesheet)
        //{
        //    TimeSheets.Add(timesheet);

        //}

        //void ITimeTrackerDataSource.deleteTimeSheet(TimeSheet timesheet)
        //{
        //    TimeSheets.Remove(timesheet);

        //}

        //void ITimeTrackerDataSource.editTimeSheet(TimeSheet timesheet)
        //{
        //    Entry(timesheet).State = EntityState.Modified;

        //}

        //// Methods for TimeSheetEntry

        //void ITimeTrackerDataSource.addTimeSheetEntry(TimeSheetEntry entry)
        //{
        //    TimeSheetEntries.Add(entry);

        //}

        //void ITimeTrackerDataSource.deleteTimeSheetEntry(TimeSheetEntry entry) {

        //    TimeSheetEntries.Remove(entry);        
        //}

        //void ITimeTrackerDataSource.editTimeSheetEntry(TimeSheetEntry entry) {

        //  Entry(entry).State = EntityState.Modified;
            
            
        //}

        //IQueryable<Project> ITimeTrackerDataSource.Projects
        //{
        //    get { return Projects; }
        //}

        //IQueryable<Company> ITimeTrackerDataSource.Companies
        //{
        //    get { return Companies; }
        //}

        //IQueryable<TimeSheet> ITimeTrackerDataSource.TimeSheets
        //{
        //    get { return TimeSheets; }
        //}

        //IQueryable<TimeSheetEntry> ITimeTrackerDataSource.TimeSheetEntries
        //{
        //    get { return TimeSheetEntries; }
        //}

    }
}