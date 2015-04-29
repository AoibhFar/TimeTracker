using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using timeTracker.Web.Controllers;
using System.Web.Mvc;
using timeTracker.Web.Tests.Fakes;

namespace timeTracker.Web.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void About()
        {
            // Arrange 
            var db = new FakeTimeTrackerDb();
            var controller = new HomeController(db);

            // Act

            ViewResult result = controller.About() as ViewResult;

            //Assert
            Assert.IsNotNull(result.Model);
            
        }

    }
}
