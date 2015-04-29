using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using timeTracker.Domain;
using timeTracker.Web.Infrastructure;
using timeTracker.Web.ViewModels;
using PagedList;


namespace timeTracker.Web.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ITimeTrackerDataSource _data;

        public CompanyController(ITimeTrackerDataSource data)
      
        {
            _data = data;
        }

        public ActionResult Index(string sortOrder, string currentFilter,string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ContactNameSortParam = String.IsNullOrEmpty(sortOrder) ? "contact_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var companies = _data.Query<Company>();

            if (!String.IsNullOrEmpty(searchString))
            {
                companies = _data.Query<Company>().Where(c => c.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    companies = companies.OrderByDescending(c => c.Name);
                    break;

                case "contact_desc":
                    companies = companies.OrderByDescending(c => c.Contactperson);
                    break;
                
                default:
                    companies = companies.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(companies.ToPagedList(pageNumber,pageSize));
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
           
            var model = _data.Query<Company>().Single(d => d.Id == id);
            
            if (model == null)
            {
                return HttpNotFound();
            } 

            return View(model);
        }


        // GET: Company/Create
        [Authorize(Roles="Admin")]
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

                _data.Add(company);
                _data.Save();

                return RedirectToAction("Index", "Company");
            }

            return View(viewModel);
        }

        // GET: Company/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var company = _data.Query<Company>().Single(c => c.Id == id);

            if (company == null)
            {
                return HttpNotFound();
            } 
            return View(company);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _data.Update(company);
                _data.Save();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Company/Delete/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = _data.Query<Company>().Single(t => t.Id == id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var company = _data.Query<Company>().Single(t => t.Id == id);
            _data.Remove(company);
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
