using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using timeTracker.Domain;
using timeTracker.Web.Infrastructure;
using timeTracker.Web.Models;
using timeTracker.Web.ViewModels;

namespace timeTracker.Web.Controllers
{
    [Authorize]
    public class TimeSheetController : Controller
    {

        private readonly ITimeTrackerDataSource _data;

        public TimeSheetController(ITimeTrackerDataSource data)
       
        {
            _data = data;
        }

        public ActionResult Index()
        {
            var allTimesheets = _data.TimeSheets;
            return View(allTimesheets);
        }

     

        // GET: TimeSheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var timesheet = _data.TimeSheets.Single(t => t.Id == id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // GET: TimeSheet/Create
        [HttpGet]
        public ActionResult Create()
        {

            var model = new CreateTimeSheetViewModel();
            model.OwnerId = User.Identity.GetUserId();
            model.OwnerName = User.Identity.GetUserName();
            return View(model);
        }


        // POST: TimeSheet/Create
        [HttpPost]
        public ActionResult Create(CreateTimeSheetViewModel viewModel)
        {
           
            if (ModelState.IsValid)
            {
                var timesheet = new TimeSheet
                {
                    OwnerId = viewModel.OwnerId,
                    OwnerName = viewModel.OwnerName,
                    WeeklyHours = viewModel.WeeklyHours,
                    WeekStarting = viewModel.WeekStarting
                };

                _data.addTimeSheet(timesheet);
                _data.Save();

                return RedirectToAction("index", "timesheet");
            }

            return View(viewModel);
        }


        // GET: TimeSheet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timeSheet = _data.TimeSheets.Single(t => t.Id == id);

            if (timeSheet == null)
            {
                return HttpNotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,WeekStarting,WeeklyHours")] TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                _data.editTimeSheet(timeSheet);
                _data.Save();
                return RedirectToAction("Index");
            }
            return View(timeSheet);
        }

        // GET: TimeSheet/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timeSheet = _data.TimeSheets.Single(t => t.Id == id);
            if (timeSheet == null)
            {
                return HttpNotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var timeSheet = _data.TimeSheets.Single(t => t.Id == id);
            _data.deleteTimeSheet(timeSheet);
            _data.Save();
            return RedirectToAction("Index");
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
