
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using timeTracker.Web.Models;
using timeTracker.Web.Infrastructure;
using timeTracker.Web.ViewModels;
using PagedList;

namespace timeTracker.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class UserController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public UserStore<ApplicationUser> UserStore { get; private set; }
        public  TimeTrackerDb context { get; private set; }
   

        public UserController() 
        {
            context = new TimeTrackerDb();
            UserStore = new UserStore<ApplicationUser>(context);
            UserManager = new UserManager<ApplicationUser>(UserStore);
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        
        }

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, UserStore<ApplicationUser> userStore)
        {
            UserStore = userStore;
            UserManager = userManager;
            RoleManager = roleManager;
        }

       
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

            var users = from user in context.Users
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

            return View(users.ToPagedList(pageNumber, pageSize));

            
        }

        //GET: /User/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            return View(user);
        }

        //Get: /User/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUser edituser)
        {
            var id = edituser.Id;
            var user = await UserManager.FindByIdAsync(id);
            if (ModelState.IsValid)
            {
                user.Id =edituser.Id;
                user.Name = edituser.Name;
                user.BirthDate = edituser.BirthDate;
                user.Department = edituser.Department;
                user.Role = edituser.Role;
                user.Manager = edituser.Manager;
                user.Hourlyrate = edituser.Hourlyrate;
                user.Holidays = edituser.Holidays;
                user.HolidaysTaken = edituser.HolidaysTaken;
                user.Email = edituser.Email;
                user.PhoneNumber = edituser.PhoneNumber;
                user.UserName = edituser.UserName;
                
                // Update the users details
                await UserManager.UpdateAsync(user);

                return RedirectToAction("Index");
            }

            return View(user);

        }


        // GET: /Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = context.Users.First(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await UserManager.FindByIdAsync(id);
                var logins = user.Logins;
                foreach (var login in logins)
                {
                    await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                   
                }
                var rolesForUser = await UserManager.GetRolesAsync(id);

                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        // item should be the name of the role
                        var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                    }
                }

                await UserManager.DeleteAsync(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}