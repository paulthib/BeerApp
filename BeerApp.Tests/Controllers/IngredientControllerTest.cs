using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Beer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerApp;
using BeerApp.Controllers;
using BeerApp.Models;
using BeerApp.Tests.Repository;

namespace BeerApp.Tests.Controllers
{
    [TestClass]
    public class IngredientControllerTest
    {
        private IngredientController _controller;

        [TestInitialize]
        public void Test_Setup()
        {
            _controller = new IngredientController(new TestIngredientRepository());
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
            Assert.AreEqual(6, result.Content.Count());

        }

        [TestMethod]
        public void Test_Add()
        {
            string name = "New Ingredient";
            // Act
            var result0 = _controller.Get(name);
            Assert.IsNull(result0);

            var result = _controller.Get();
            int cnt = result.Content.Count();

            _controller.Post(new IngredientViewModel() { Id = 1, Name = name, Units = "Cups" });
            result = _controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cnt+1, result.Content.Count());

            // Act
            var result2 = _controller.Get(name);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result2.Name);

        }
    }
}
