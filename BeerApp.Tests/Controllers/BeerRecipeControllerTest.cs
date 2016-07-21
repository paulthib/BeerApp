using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Beer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerApp;
using BeerApp.Controllers;
using BeerApp.Models;
using BeerApp.Tests.Repository;
using System;

namespace BeerApp.Tests.Controllers
{
    [TestClass]
    public class BeerRecipeControllerTest
    {
        private BeerRecipeController _controller;

        [TestInitialize]
        public void Test_Setup()
        {
            _controller = new BeerRecipeController(new TestRecipeRepository());
        }

        [TestMethod]
        public void Test_Search()
        {
            // Arrange
            var name = "My Brew";
            BeerRecipeViewModel model = CreateRecipe(name);
             
            _controller.Post(model);

            // Act
            var result = _controller.Get(name) ;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Name);

        }

        public void Test_Search_NotFound()
        {
            // Arrange

            // Act
            var result = _controller.Get("notfound");

            // Assert
            Assert.IsNull(result);

        }

        [TestMethod]
        public void Test_GetAll()
        {
            // Arrange

            // Act
            var result = _controller.Get() ;

            // Assert
            Assert.AreEqual(2, result.Content.Count());

        }

        #region Support Methods
        private BeerRecipeViewModel CreateRecipe(string name)
        {
            List<RecipeIngredientVm> ingredients = new List<RecipeIngredientVm>();
            ingredients.Add(new RecipeIngredientVm() { Id = 1, Name = "Cascade Hops", Quantity = 10 });
            ingredients.Add(new RecipeIngredientVm() { Id = 1001, Name = "Barley", Quantity = 100 });
            BeerRecipeViewModel model = new BeerRecipeViewModel
            {
                Name = name,
                BeerType = "Porter",
                Description = "Tasty",
                Ingredients = ingredients
            };
            return model;
        }
        #endregion Support Methods
    }
}
