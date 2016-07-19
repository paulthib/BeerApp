using System.Collections.Generic;
using System.Web.Mvc;
using Beer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerApp;
using BeerApp.Controllers;
using BeerApp.Models;

namespace BeerApp.Tests.Controllers
{
    [TestClass]
    public class BeerRecipeControllerTest
    {
        [TestMethod]
        public void Test_Search()
        {
            // Arrange
            BeerRecipeController controller = new BeerRecipeController(new RecipeRepository());

            var name = "My Brew";
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

            controller.Post(model);

            // Act
            var result = controller.Get(name) ;

            // Assert
            Assert.IsNotNull(result);
             
        }
    }
}
