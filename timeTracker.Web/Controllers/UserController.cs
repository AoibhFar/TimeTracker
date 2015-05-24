using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timeTracker.Web.Infrastructure;
using timeTracker.Web.ViewModels;
using PagedList;
using timeTracker.Web.Models;

namespace timeTracker.Web.Controllers
{
    public class UserController : Controller
    {
        TimeTrackerDb db = new TimeTrackerDb();
        // GET: Users
        public ActionResult Index(string sortOrder, string currentFilter,string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RoleSortParam = String.IsNullOrEmpty(sortOrder) ? "role_desc" : "";
            ViewBag.DepartmentSortParam = String.IsNullOrEmpty(sortOrder) ? "dept_desc" : "";
            ViewBag.EmailNameSortParam = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var users = from user in db.Users
                        select user;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                   users = users.OrderByDescending(u => u.Name);
                    break;

                case "role_desc":
                    users = users.OrderByDescending(u => u.Role);
                    break;

                case "dept_desc":
                    users = users.OrderByDescending(u => u.Department);
                    break;

                case "email_desc":
                    users = users.OrderByDescending(u => u.Email);
                    break;

                default:
                    users = users.OrderBy(u => u.Name);
                    break;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var allusers = users.Select(user => new UserViewModel { Username = user.Name, Role = user.Role, Department = user.Department, Email = user.Email, Id = user.Id }).ToList();

            return View(allusers.ToPagedList(pageNumber, pageSize));

            //var allusers = db.Users.ToList();
            //var users = allusers.Select(user => new UserViewModel { Username = user.Name, Role = user.Role, Department = user.Department, Email = user.Email, Id = user.Id }).ToList();
            //var model = new GroupedUserViewModel { Users = users };
            //return View(model);
            
        }

        // GET: User/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var user = db.Users.First(u => u.UserName == username);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}