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
    public class TimeSheetEntryController : Controller
    {

        private readonly ITimeTrackerDataSource _data;
        
         public TimeSheetEntryController(ITimeTrackerDataSource data)
       
        {
            // GET: TimeSheet
            _data = data;
        }

        // GET: TimeSheetEntry
        public ActionResult Index()
        {
            return View();
        }

        // GET: TimeSheetEntry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timesheetentry = _data.TimeSheets.Single(t => t.Id == id);
            if (timesheetentry == null)
            {
                return HttpNotFound();
            }
            return View(timesheetentry);
        }

        // GET: TimeSheetEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSheet/Create
        public ActionResult Create(CreateTimeSheetEntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var timesheetentry = new TimeSheetEntry
                {

                };

                _data.addTimeSheetEntry(timesheetentry);
                _data.Save();

                return RedirectToAction("index", "timesheetentry");
            }

            return View(viewModel);
        }

        // GET: TimeSheetEntry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TimeSheetEntry timesheetentry = _data.TimeSheetEntries.Where(t => t.Id == id).Single();
            if (timesheetentry == null)
            {
                return HttpNotFound();
            }
            return View(timesheetentry);
        }

        //// POST: TimeSheetEntry/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,EmployeeId,CompanyId,ProjectId,Notes,Billable,Day,Workdate")] TimeSheetEntry timeSheetEntry)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _data.Entry(timeSheetEntry).State = EntityState.Modified;
        //        _data.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(timeSheetEntry);
        //}

        //// GET: TimeSheetEntry/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TimeSheetEntry timeSheetEntry = _data.TimeSheetEntries.Find(id);
        //    if (timeSheetEntry == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(timeSheetEntry);
        //}

        //// POST: TimeSheetEntry/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    TimeSheetEntry timeSheetEntry = _data.TimeSheetEntries.Find(id);
        //    _data.TimeSheetEntries.Remove(timeSheetEntry);
        //    _data.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
