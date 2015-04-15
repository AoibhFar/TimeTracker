using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using timeTracker.Domain;
using System.Linq;

namespace timeTracker.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<TimeSheet> TimeSheets { get; set; }
        //public DbSet<TimeSheetEntry> TimeSheetEntries { get; set; }
    
        //void ITimeTrackerDataSource.Save()
        //{
        //    SaveChanges();
        //}

        //IQueryable<Employee> ITimeTrackerDataSource.Employees
        //{
        //    get { return Employees; }
        //}

        //IQueryable<Project> ITimeTrackerDataSource.Projects
        //{
        //    get {return Projects; }
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