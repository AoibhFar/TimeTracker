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

namespace timeTracker.Web.Controllers
{
    public class TimeSheetEntryController : Controller
    {

        //private readonly ITimeTrackerDataSource _data;

        private TimeTrackerDb _data = new TimeTrackerDb();

        //public TimeSheetController(ITimeTrackerDataSource data)
        public TimeSheetEntryController(TimeTrackerDb data)
        {
            // GET: TimeSheet
            _data = data;
        }

        // GET: TimeSheetEntry
        public ActionResult Index()
        {
            return View(_data.TimeSheetEntries.ToList());
        }

        // GET: TimeSheetEntry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetEntry timeSheetEntry = _data.TimeSheetEntries.Find(id);
            if (timeSheetEntry == null)
            {
                return HttpNotFound();
            }
            return View(timeSheetEntry);
        }

        // GET: TimeSheetEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSheetEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,CompanyId,ProjectId,Notes,Billable,Day,Workdate")] TimeSheetEntry timeSheetEntry)
        {
            if (ModelState.IsValid)
            {
                _data.TimeSheetEntries.Add(timeSheetEntry);
                _data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeSheetEntry);
        }

        // GET: TimeSheetEntry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetEntry timeSheetEntry = _data.TimeSheetEntries.Find(id);
            if (timeSheetEntry == null)
            {
                return HttpNotFound();
            }
            return View(timeSheetEntry);
        }

        // POST: TimeSheetEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,CompanyId,ProjectId,Notes,Billable,Day,Workdate")] TimeSheetEntry timeSheetEntry)
        {
            if (ModelState.IsValid)
            {
                _data.Entry(timeSheetEntry).State = EntityState.Modified;
                _data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeSheetEntry);
        }

        // GET: TimeSheetEntry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetEntry timeSheetEntry = _data.TimeSheetEntries.Find(id);
            if (timeSheetEntry == null)
            {
                return HttpNotFound();
            }
            return View(timeSheetEntry);
        }

        // POST: TimeSheetEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSheetEntry timeSheetEntry = _data.TimeSheetEntries.Find(id);
            _data.TimeSheetEntries.Remove(timeSheetEntry);
            _data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _data.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
