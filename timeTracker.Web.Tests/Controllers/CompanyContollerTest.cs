using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using timeTracker.Web.Controllers;
using System.Web.Mvc;
using timeTracker.Web.Tests.Fakes;
using timeTracker.Web.Models;
using timeTracker.Web.ViewModels;
using timeTracker.Domain;
using System.Linq;


namespace timeTracker.Web.Tests.Controllers
{
    [TestClass]
    public class CompanyContollerTest
    {

        [TestMethod]
        public void Create_Saves_Company_When_Valid()
        {
            // Arrange
            var db = new FakeTimeTrackerDb();
            var controller = new CompanyController(db);

            // Act
            controller.Create(new CreateCompanyViewModel());

            //Assert
            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.Saved);
        }

        [TestMethod]
        public void Create_Does_not_Save_Company_When_Invalid()
        {
            // Arrange
            var db = new FakeTimeTrackerDb();
            var controller = new CompanyController(db);

            //Act
            controller.ModelState.AddModelError("", "Invalid");
            controller.Create(new CreateCompanyViewModel());

            //Assert
            Assert.AreEqual(0, db.Added.Count);
        }

        [TestMethod]
        public void Details_Is_Not_Null()
        {
            // Arrange
            var db = new FakeTimeTrackerDb();
            db.AddSet(TestData.Companies);
            var controller = new CompanyController(db);

            //Act
            ViewResult result = controller.Details(1) as ViewResult;
            
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_Saves_Company_When_Valid(){

            // Arrange
            var db = new FakeTimeTrackerDb();
            db.AddSet(TestData.Companies);
            var controller = new CompanyController(db);
            var company = db.Query<Company>().Single(c => c.Id == 1);

            // Act
            controller.Edit(company);

            //Assert
            Assert.AreEqual(1, db.Updated.Count);
            Assert.AreEqual(true, db.Saved);
        }

        [TestMethod]
        public void Edit_Saves_Company_When_Invalid()
        {
            // Arrange
            var db = new FakeTimeTrackerDb();
            db.AddSet(TestData.Companies);
            var controller = new CompanyController(db);
            var company = db.Query<Company>().Single(c => c.Id == 1);

            //Act
            controller.ModelState.AddModelError("", "Invalid");
            controller.Edit(company);

            //Assert
            Assert.AreEqual(0, db.Updated.Count);
        }
    }
}
