using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Beer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerApp;
using BeerApp.Controllers;
using BeerApp.Models;

namespace BeerApp.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerTest
    {
        private IngredientController _controller;

        [TestInitialize]
        public void Test_Setup()
        {
            _controller = new IngredientController(new IngredientRepository());

            _controller.Post(new IngredientViewModel() { Id = 1, Name = "Cascade Hops", Units = "Cups" });
            _controller.Post(new IngredientViewModel() { Id = 1, Name = "Barley", Units = "Cups" });

        }

        [TestMethod]
        public void Test_Search()
        {

            // Act
            var result = _controller.Get("Barley") ;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Barley", result.Name);

        }

        [TestMethod]
        public void Test_GetAll()
        {

            // Act
            var result = _controller.Get( );

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());

        }
    }
}
