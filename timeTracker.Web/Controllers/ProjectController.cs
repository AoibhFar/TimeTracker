using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using timeTracker.Domain;
using timeTracker.Web.ViewModels;

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
             var allProjects = _data.Query<Project>().ToList();
             return View(allProjects);
         }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            var model = _data.Query<Project>().Single(d => d.Id == id);
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
                var company = _data.Query<Company>().Single(c => c.Name == viewModel.Company);

                //Create a new project
                var project = new Project
                {
                    Name = viewModel.Name,
                    Company = viewModel.Company,
                    CompanyId = company.Id,
                    Description = viewModel.Description,
                    Startdate = viewModel.Startdate,
                    Finishdate = viewModel.Finishdate
                };

                //Add it to the Company's list of projects
                company.Projects.Add(project);
                _data.Add(project);
                _data.Save();
                return RedirectToAction("details", "company", new {id = viewModel.CompanyId});
            }
            return View(viewModel);
        }

        // GET: Project/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = _data.Query<Project>().Single(t => t.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //POST: TimeSheetEntry/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                _data.Update(project);
                _data.Save();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: TimeSheetEntry/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
 
            var project = _data.Query<Project>().Single(t => t.Id == id);
            
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            var project = _data.Query<Project>().Single(t => t.Id == id);
            var company = _data.Query<Company>().Single(d => d.Id == project.CompanyId);
            _data.Remove(project);
            _data.Save();
            return RedirectToAction("details", "company", new { id = project.CompanyId });
        }

        protected override void Dispose(bool disposing)
        {
            _data.Dispose();
            base.Dispose(disposing);
        }

      
    }
}
