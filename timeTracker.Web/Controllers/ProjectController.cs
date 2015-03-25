using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timeTracker.Domain;
using timeTracker.Web.Models;

namespace timeTracker.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ITimeTrackerDataSource _data;

         public ProjectController(ITimeTrackerDataSource data)
        {
            _data = data;
        }

        // GET: Company
         public ActionResult Index()
         {
             var allProjects = _data.Projects;
             return View(allProjects);
         }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            var model = _data.Projects.Single(d => d.Id == id);
            return View(model);
        }

       [HttpGet]
        public ActionResult Create(int companyId, string companyName)
        {
            var model = new CreateProjectViewModel();
            model.CompanyId = companyId;
            model.Company = companyName;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateProjectViewModel viewModel )
        {
            if(ModelState.IsValid)
            {
                //Get the related Company
                var company = _data.Companies.Single(d => d.Id == viewModel.CompanyId);

                //Create a new project
                var project = new Project
                {
                    Name = viewModel.Name,
                    Company = viewModel.Company,
                    Description = viewModel.Description,
                    Startdate = viewModel.Startdate,
                    Finishdate = viewModel.Finishdate
                };

                //Add it to the Company's list of projects
                company.Projects.Add(project);

                _data.Save();
                return RedirectToAction("details", "company", new {id = viewModel.CompanyId});
            }
            return View(viewModel);
        }

      
    }
}
