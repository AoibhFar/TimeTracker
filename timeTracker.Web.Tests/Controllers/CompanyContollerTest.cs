using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using timeTracker.Web.Controllers;
using System.Web.Mvc;
using timeTracker.Web.Tests.Fakes;
using timeTracker.Web.Models;
using timeTracker.Web.ViewModels;


namespace timeTracker.Web.Tests.Controllers
{
    [TestClass]
    public class CompanyContollerTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
          

            //Act
           

            //Assert

        }

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
        public void Create_Does_not_Save_Comapny_When_Invalid()
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
    }
}
