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
using PagedList;

namespace timeTracker.Web.Controllers
{
    [Authorize]
    public class TimeSheetController : Controller
    {

        private readonly ITimeTrackerDataSource _data;
        IdentityDbContext context = new IdentityDbContext();


        public TimeSheetController(ITimeTrackerDataSource data)
       
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
            var timesheets = _data.Query<TimeSheet>();

            if (!String.IsNullOrEmpty(searchString))
            {
                timesheets = _data.Query<TimeSheet>().Where(t => t.OwnerName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    timesheets = timesheets.OrderByDescending(t => t.OwnerName);
                    break;

                case "date_desc":
                    timesheets = timesheets.OrderByDescending(t => t.WeekStarting);
                    break;

                default:
                    timesheets = timesheets.OrderBy(t => t.OwnerName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(timesheets.ToPagedList(pageNumber, pageSize));
        }

     

        // GET: TimeSheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var timesheet = _data.Query<TimeSheet>().Single(t => t.Id == id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            var entries = (from e in _data.Query<TimeSheetEntry>()
                           where e.TimeSheetId == id
                           select e).ToList();
            var total = 0;
            foreach(TimeSheetEntry e in entries){

                total = total + e.Hours;
            }
            ViewBag.TotalHours = total;

            ViewBag.Entries = (from e in _data.Query<TimeSheetEntry>()
                           where e.TimeSheetId == id
                           select e).OrderBy(e => e.Workdate).ToList();
           

            return View(timesheet);
        }

        // GET: TimeSheet/Create
        [HttpGet]
        public ActionResult Create()
        {
         
          ViewBag.Employees = (from u in context.Users
                               select new SelectListItem { Text = u.UserName }).ToList();
            
            var model = new CreateTimeSheetViewModel();
            return View(model);
        }


        // POST: TimeSheet/Create
        [HttpPost]
        public ActionResult Create(CreateTimeSheetViewModel viewModel)
        {
           
            if (ModelState.IsValid)
            {
                var user = (from u in context.Users
                            where u.UserName == viewModel.OwnerName
                            select u).Single();
                var timesheet = new TimeSheet
                {
                    OwnerId = user.Id,
                    OwnerName = viewModel.OwnerName,
                    WeeklyHours = viewModel.WeeklyHours,
                    WeekStarting = viewModel.WeekStarting
                };
                 _data.Add(timesheet);
                _data.Save();
                TempData["Message"] = "Added";
                TempData["Name"] = timesheet.OwnerName;
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
            var timeSheet = _data.Query<TimeSheet>().Single(t => t.Id == id);

            if (timeSheet == null)
            {
                return HttpNotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                _data.Update(timeSheet);
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
            var timeSheet = _data.Query<TimeSheet>().Single(t => t.Id == id);
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
            var timeSheet = _data.Query<TimeSheet>().Single(t => t.Id == id);
            _data.Remove(timeSheet);
            _data.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _data.Dispose();
            base.Dispose(disposing);
        }

    }
}
