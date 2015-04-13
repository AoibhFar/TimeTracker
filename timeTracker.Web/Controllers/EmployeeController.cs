using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timeTracker.Domain;
using timeTracker.Web.ViewModels;

namespace timeTracker.Web.Controllers
{
    public class EmployeeController : Controller
    {
       private readonly ITimeTrackerDataSource _data;

         public EmployeeController(ITimeTrackerDataSource data)
        {
            _data = data;
        }

        // GET: Company
         public ActionResult Index()
         {
             var allEmployeess = _data.Employees;
             return View(allEmployeess);
         }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var model = _data.Employees.Single(d => d.Id == id);
            return View(model);
        }

        [Authorize(Roles="canEdit")]
        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = viewModel.Name,
                    Department = viewModel.Department,
                    Role = viewModel.Role,
                    Manager = viewModel.Manager
                    
                };

                _data.Save();

                return RedirectToAction("index", "employee");
            }

            return View(viewModel);
        }

        //// GET: Employee/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Edit/5
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

        //// GET: Employee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Delete/5
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
