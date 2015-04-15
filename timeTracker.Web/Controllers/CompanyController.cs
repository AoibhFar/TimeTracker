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
    public class CompanyController : Controller
    {

        //private readonly ITimeTrackerDataSource _data;

        private TimeTrackerDb _data = new TimeTrackerDb();

         //public CompanyController(ITimeTrackerDataSource data)
        public CompanyController(TimeTrackerDb data)
        {
            _data = data;
        }

        // GET: Company
         public ActionResult Index()
         {
             var allCompanies = _data.Companies;
             return View(allCompanies);
         }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            var model = _data.Companies.Single(d => d.Id == id);
            return View(model);
        }


        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(CreateCompanyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var company = new Company
                {
                    Name = viewModel.Name,
                    Contactperson = viewModel.Contactperson,
                    Contactnumber = viewModel.Contactemail,
                    Contactemail = viewModel.Contactemail,
                    Description = viewModel.Description
                };

                _data.Companies.Add(company);
                _data.SaveChanges();
                //_data.Save();

                return RedirectToAction("index", "company");
            }

            return View(viewModel);
        }

        //// GET: Company/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Company/Edit/5
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

        //// GET: Company/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Company/Delete/5
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
