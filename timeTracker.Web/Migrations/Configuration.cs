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
            if (!context.Users.Any(u => u.UserName == "Admin User"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { 
                    
                    Name = "Admin User",
                    UserName = "admin@mail.com", 
                    Email = "admin@mail.com" ,
                    Department = "Administration",

                };

                userManager.Create(user, "ChangeItAsap0!");
                userManager.AddToRole(user.Id, "Admin");
            }

            //if (!context.Users.Any(u => u.UserName == "Guest User"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser
            //    {

            //        Name = "Guest User",
            //        UserName = "Guest User",
            //        Email = "guest@mail.com",
            //        Department = "Guest",

            //    };

            //    userManager.Create(user, "Guest1!");
            //    userManager.AddToRole(user.Id, "User");
            //}

            context.Companies.AddOrUpdate(d => d.Name,
                new Company() { Name = "HydroP", Contactperson = "Ann Reilly", Contactemail = "areilly@gmail.com", Contactnumber = "01 4578995", Description = "Renewable Energy Engineering" },
                new Company() { Name = "DCA Ltd", Contactperson = "Joe Bloggs", Contactemail = "jbloggs@gmail.com", Contactnumber = "01 9653325", Description = "Chartered Accountants" },
                new Company() { Name = "Paws a While", Contactperson = "Mary Smith", Contactemail = "paws@gmail.com", Contactnumber = "01 568563454", Description = "Animal Charity" },
                new Company() { Name = "Jupitor Engineering", Contactperson = "David Buckley", Contactemail = "dbuckley@gmail.com", Contactnumber = "01 49834675", Description = "Civil Engineering" }
            );

        }
    }
}
