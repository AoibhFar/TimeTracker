namespace timeTracker.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using timeTracker.Domain;
    using timeTracker.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<timeTracker.Web.Infrastructure.TimeTrackerDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(timeTracker.Web.Infrastructure.TimeTrackerDb context)
        {

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };
                roleManager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "admin@mail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@mail.com" };

                userManager.Create(user, "ChangeItAsap0!");
                userManager.AddToRole(user.Id, "Admin");
            }

            context.Companies.AddOrUpdate(d => d.Name,
                new Company() { Name = "HydroP", Contactperson = "Ann Reilly", Contactemail = "areilly@gmail.com", Contactnumber = "01 4578995", Description = "Renewable Energy Engineering" },
                new Company() { Name = "DCA Ltd", Contactperson = "Joe Bloggs", Contactemail = "jbloggs@gmail.com", Contactnumber = "01 9653325", Description = "Chartered Accountants" },
                new Company() { Name = "Paws a While", Contactperson = "Mary Smith", Contactemail = "paws@gmail.com", Contactnumber = "01 568563454", Description = "Animal Charity" },
                new Company() { Name = "Jupitor Engineering", Contactperson = "David Buckley", Contactemail = "dbuckley@gmail.com", Contactnumber = "01 49834675", Description = "Civil Engineering" }
            );

            context.Employees.AddOrUpdate(d => d.Name,
                new Employee() { Name = "Aoibheann Farrell", Department = "Development", Role = "App developer", Manager = "Avril" },
                new Employee() { Name = "Damien Reynolds", Department = "Development", Role = "SharePoint developer", Manager = "Avril" },
                new Employee() { Name = "Lorna Flynn", Department = "Sales", Role = "Sales Consultant", Manager = "Mary" },
                new Employee() { Name = "Chris Fagan", Department = "Marketing", Role = "Marketing Intern", Manager = "David" }

            );

        }
    }
}
