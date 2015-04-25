using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using timeTracker.Web.Controllers;
using System.Web.Mvc;

namespace timeTracker.Web.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeActionReturnsIndexView()
        {
            // Arrange 
            var homeController = new HomeController();

            // Act
            var result = homeController.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }

    }
}
