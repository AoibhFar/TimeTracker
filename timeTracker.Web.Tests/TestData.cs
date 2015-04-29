using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timeTracker.Web.ViewModels;
using timeTracker.Web.Models;
using timeTracker.Domain;


namespace timeTracker.Web.Tests
{
    class TestData
    {
        public static IQueryable<Company> Comapnies
        {
            get
            {
                var companies = new List<Company>();

                for (int i = 0; i < 100; i++)
                {
                    var company = new Company();
                    company.Projects = new List<Project>(){
                        new Project { Id = i}
                    };
                    companies.Add(company);
                }
                return companies.AsQueryable();
            }
        }
    }
}
