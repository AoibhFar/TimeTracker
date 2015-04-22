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

        // GET: TimeSheetEntry
        public ActionResult Index()
        {
            var allTimesheetEntries = _data.TimeSheetEntries;
            return View(allTimesheetEntries);
        }

        // GET: TimeSheetEntry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timesheetentry = _data.TimeSheetEntries.Single(t => t.Id == id);
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
            ViewBag.Companies = (from c in _data.Companies
                                 select new SelectListItem{Text = c.Name}).ToList();

            ViewBag.Projects = (from p in _data.Projects
                                select new SelectListItem{Text = p.Name}).ToList();

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
                //Get the related TimeSheet
                var timesheet = _data.TimeSheets.Single(d => d.Id == viewModel.TimeSheetId);
                var company = _data.Companies.Single(c => c.Name == viewModel.CompanyName);
                var project = _data.Projects.Single(p => p.Name == viewModel.ProjectName);
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
                _data.addTimeSheetEntry(timesheetentry);
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
            var timesheetentry = _data.TimeSheetEntries.Single(t => t.Id == id);
            if (timesheetentry == null)
            {
                return HttpNotFound();
            }
            return View(timesheetentry);
        }

        //POST: TimeSheetEntry/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "Id,CompanyName,ProjectName,Notes,Billable,Day,Hours,Workdate")]
        public ActionResult Edit( TimeSheetEntry timesheetentry)
        {
            if (ModelState.IsValid)
            {
                _data.editTimeSheetEntry(timesheetentry);
                _data.Save();
                return RedirectToAction("Index");
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
            var timesheetentry = _data.TimeSheetEntries.Single(t => t.Id == id);
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
            //Get the TimeSheetEntry and related TimeSheet
            var timesheetentry = _data.TimeSheetEntries.Single(t => t.Id == id);
            var timesheet = _data.TimeSheets.Single(d => d.Id == timesheetentry.TimeSheetId);
            _data.deleteTimeSheetEntry(timesheetentry);
            _data.Save();
            return RedirectToAction("details", "timesheet", new { id = timesheetentry.TimeSheetId });
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _data.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
