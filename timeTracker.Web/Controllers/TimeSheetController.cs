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
    public class TimeSheetController : Controller
    {

        //private readonly ITimeTrackerDataSource _data;

        private TimeTrackerDb _data = new TimeTrackerDb();

         //public TimeSheetController(ITimeTrackerDataSource data)
        public TimeSheetController(TimeTrackerDb data)
        {
            _data = data;
        }
        // GET: TimeSheet
        public ActionResult Index()
        {
            return View();
        }

        // GET: TimeSheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeSheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSheet/Create
        [HttpPost]
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

        //// GET: TimeSheet/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TimeSheet/Edit/5
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

        //// GET: TimeSheet/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TimeSheet/Delete/5
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
