using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using timeTracker.Domain;
using timeTracker.Web.Infrastructure;
using timeTracker.Web.ViewModels;
using PagedList;

namespace timeTracker.Web.Controllers
{
    [Authorize]
    public class TimeSheetEntryController : Controller
    {

        private readonly ITimeTrackerDataSource _data;
        
         public TimeSheetEntryController(ITimeTrackerDataSource data)
       
        {
            _data = data;
        }

         public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
         {
             ViewBag.CurrentSort = sortOrder;
             ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
             ViewBag.DateSortParam = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

             if (searchString != null)
             {
                 page = 1;
             }
             else
             {
                 searchString = currentFilter;
             }
             ViewBag.CurrentFilter = searchString;
             var entries = _data.Query<TimeSheetEntry>();

             if (!String.IsNullOrEmpty(searchString))
             {
                 entries = _data.Query<TimeSheetEntry>().Where(t => t.OwnerName.Contains(searchString));
             }

             switch (sortOrder)
             {
                 case "name_desc":
                     entries = entries.OrderByDescending(t => t.OwnerName);
                     break;

                 case "date_desc":
                     entries = entries.OrderByDescending(t => t.Workdate);
                     break;

                 default:
                     entries = entries.OrderBy(t => t.OwnerName);
                     break;
             }

             int pageSize = 3;
             int pageNumber = (page ?? 1);

             return View(entries.ToPagedList(pageNumber, pageSize));
         }

        // GET: TimeSheetEntry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timesheetentry = _data.Query<TimeSheetEntry>().Single(t => t.Id == id);
            if (timesheetentry == null)
            {
                return HttpNotFound();
            }
            return View(timesheetentry);
        }

        // GET: TimeSheetEntry/Create
        [HttpGet]
        public ActionResult Create(int timesheetId)
        {
            ViewBag.Companies = (from c in _data.Query<Company>()
                                 select new SelectListItem { Text = c.Name }).ToList();

            ViewBag.Projects = (from p in _data.Query<Project>()
                                select new SelectListItem { Text = p.Name }).ToList();

            ViewBag.Days = new List<SelectListItem>
           {
               new SelectListItem { Text = "Mon", Value = "Mon", Selected = true},
               new SelectListItem { Text = "Tue", Value = "Tues"},
               new SelectListItem { Text = "Wed", Value = "Wed"},
               new SelectListItem { Text = "Thurs",Value = "Thurs"},
               new SelectListItem { Text = "Fri", Value = "Fri"},
           };

            var model = new CreateTimeSheetEntryViewModel();
            model.TimeSheetId = timesheetId;
            model.OwnerId = User.Identity.GetUserId();
            model.OwnerName = User.Identity.GetUserName();
            return View(model);
        }

        // POST: TimeSheetEntry/Create
        [HttpPost]
        public ActionResult Create(CreateTimeSheetEntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var timesheet = _data.Query<TimeSheet>().Single(d => d.Id == viewModel.TimeSheetId);
                
                var company = _data.Query<Company>().Single(c => c.Name == viewModel.CompanyName);
                var project = _data.Query<Project>().Single(p => p.Name == viewModel.ProjectName);
     

                var timesheetentry = new TimeSheetEntry
                {
                   OwnerId = viewModel.OwnerId,
                   OwnerName =viewModel.OwnerName,
                   CompanyName= viewModel.CompanyName,
                   CompanyId = company.Id,
                   ProjectId = project.Id,
                   ProjectName = viewModel.ProjectName,
                   TimeSheetId = viewModel.TimeSheetId,
                   Notes = viewModel.Notes,
                   Billable = viewModel.Billable,
                   Day = viewModel.Day,
                   Hours = viewModel.Hours,
                   Workdate = viewModel.Workdate

                };

                 timesheet.TimeSheetEntries.Add(timesheetentry);
                 _data.Add(timesheetentry);
                _data.Save();

                return RedirectToAction("details", "timesheet", new { id = viewModel.TimeSheetId });
            }

            return View(viewModel);
        }

        // GET: TimeSheetEntry/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timesheetentry = _data.Query<TimeSheetEntry>().Single(t => t.Id == id);
            if (timesheetentry == null)
            {
                return HttpNotFound();
            }
            return View(timesheetentry);
        }

        //POST: TimeSheetEntry/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TimeSheetEntry timesheetentry)
        {
            if (ModelState.IsValid)
            {
                _data.Update(timesheetentry);
                _data.Save();
                return RedirectToAction("details", "timesheet", new { id = timesheetentry.TimeSheetId });
            }
            return View(timesheetentry);
        }

        // GET: TimeSheetEntry/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timesheetentry = _data.Query<TimeSheetEntry>().Single(t => t.Id == id);
            if (timesheetentry == null)
            {
                return HttpNotFound();
            }
            return View(timesheetentry);
        }

        // POST: TimeSheetEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var timesheetentry = _data.Query<TimeSheetEntry>().Single(t => t.Id == id);
            var timesheet = _data.Query<TimeSheet>().Single(d => d.Id == timesheetentry.TimeSheetId);
            _data.Remove(timesheetentry);
            _data.Save();
            return RedirectToAction("details", "timesheet", new { id = timesheetentry.TimeSheetId });
        }

        protected override void Dispose(bool disposing)
        {
            _data.Dispose();
            base.Dispose(disposing);
        }

    }
}
