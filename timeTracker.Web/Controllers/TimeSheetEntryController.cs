using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timeTracker.Domain;
using timeTracker.Web.Infrastructure;
using timeTracker.Web.ViewModels;

namespace timeTracker.Web.Controllers
{
    public class TimeSheetEntryController : Controller
    {

         //private readonly ITimeTrackerDataSource _data;

        private TimeTrackerDb _data = new TimeTrackerDb();

         //public TimeSheetEntryController(ITimeTrackerDataSource data)
        public TimeSheetEntryController(TimeTrackerDb data)
        {
            _data = data;
        }

        // GET: TimeSheetEntry
        public ActionResult Index()
        {
            return View();
        }

        // GET: TimeSheetEntry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeSheetEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSheetEntry/Create
        [HttpPost]
        public ActionResult Create(CreateTimeSheetEntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entry = new TimeSheetEntry
                {

                };

                _data.TimeSheetEntries.Add(entry);
                _data.SaveChanges();
                //_data.Save();

                return RedirectToAction("index", "timesheetentry");
            }

            return View(viewModel);
        }

        //// GET: TimeSheetEntry/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TimeSheetEntry/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TimeSheetEntry/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TimeSheetEntry/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
