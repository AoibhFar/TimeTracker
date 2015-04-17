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
    public class TimeSheetController : Controller
    {
        //private readonly ITimeTrackerDataSource _data;

        private TimeTrackerDb _data = new TimeTrackerDb();

         //public TimeSheetController(ITimeTrackerDataSource data)
        public TimeSheetController(TimeTrackerDb data)
        {
            // GET: TimeSheet
            _data = data;
        }
       
        public ActionResult Index()
        {
            return View();
        }
        // GET: TimeSheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheet timeSheet = _data.TimeSheets.Find(id);
            if (timeSheet == null)
            {
                return HttpNotFound();
            }
            return View(timeSheet);
        }

        // GET: TimeSheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSheet/Create
        public ActionResult Create(CreateTimeSheetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var timesheet = new TimeSheet
                {

                };

                _data.TimeSheets.Add(timesheet);
                _data.SaveChanges();
                //_data.Save();

                return RedirectToAction("index", "timesheet");
            }

            return View(viewModel);
        }

        //// POST: TimeSheet/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,EmployeeId,WeekStarting,WeeklyHours")] TimeSheet timeSheet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _data.TimeSheets.Add(timeSheet);
        //        _data.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(timeSheet);
        //}

        // GET: TimeSheet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheet timeSheet = _data.TimeSheets.Find(id);
            if (timeSheet == null)
            {
                return HttpNotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,WeekStarting,WeeklyHours")] TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                _data.Entry(timeSheet).State = EntityState.Modified;
                _data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeSheet);
        }

        // GET: TimeSheet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheet timeSheet = _data.TimeSheets.Find(id);
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
            TimeSheet timeSheet = _data.TimeSheets.Find(id);
            _data.TimeSheets.Remove(timeSheet);
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
