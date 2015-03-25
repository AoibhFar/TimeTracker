using timeTracker.Domain;

namespace timeTracker.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<timeTracker.Web.Infrastructure.TimeTrackerDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(timeTracker.Web.Infrastructure.TimeTrackerDb context)
        {
            context.Companies.AddOrUpdate(d=>d.Name, 
                new Company(){Name = "HydroP",Contactperson = "Ann Reilly",Contactemail = "areilly@gmail.com",Contactnumber = "01 4578995", Description = "Renewable Energy Engineering"},
                new Company(){Name = "DCA Ltd",Contactperson = "Joe Bloggs",Contactemail = "jbloggs@gmail.com",Contactnumber = "01 9653325", Description = "Chartered Accountants"},
                new Company(){Name = "Paws a While",Contactperson = "Mary Smith",Contactemail = "paws@gmail.com",Contactnumber = "01 568563454", Description = "Animal Charity"},
                new Company(){Name = "Jupitor Engineering",Contactperson = "David Buckley",Contactemail = "dbuckley@gmail.com",Contactnumber = "01 49834675", Description = "Civil Engineering"}
            );

            context.Employees.AddOrUpdate(d=>d.Name,
                new Employee() { Name = "Aoibheann Farrell", Department = "Development",Role="App developer",Manager = "Avril"},
                new Employee() { Name = "Damien Reynolds", Department = "Development", Role = "SharePoint developer", Manager = "Avril" },
                new Employee() { Name = "Lorna Flynn", Department = "Sales", Role = "Sales Consultant", Manager = "Mary" },
                new Employee() { Name = "Chris Fagan", Department = "Marketing", Role = "Marketing Intern", Manager = "David" }
                
            );

            //context.Projects.AddOrUpdate(d => d.Name,
            //    new Project() { Name = "SharePoint Site", Company = "HydroP", Description = "New SharePoint Site for Sales Department" },
            //    new Project() { Name = "CRM Application", Company = "Hydro", Description = "CRM Application for Whole Company" },
            //    new Project() { Name = "Intranet Site", Company = "DCA Ltd", Description = "New Intranet Site for Whole Company" },
            //    new Project() { Name = "WebSite", Company = "Paws a While", Description = "New External Website" },
            //    new Project() { Name = "CRM", Company = "Jupitor Engineering", Description = "CRM Application for Whole Company" }

            //   );

          
        }
    }
}
