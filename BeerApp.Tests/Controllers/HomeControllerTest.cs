using System.Web.Mvc;
using Beer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerApp;
using BeerApp.Controllers;

namespace BeerApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new IngredientRepository());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
