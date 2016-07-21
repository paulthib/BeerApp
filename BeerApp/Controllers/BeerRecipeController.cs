using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Beer.Data;
using Beer.Model;
using BeerApp.Models;

namespace BeerApp.Controllers
{
    public class BeerRecipeController : ApiController
    {
        private IGenericRepository<Recipe> _repo;
        public BeerRecipeController(IGenericRepository<Recipe> repo)
        {
            _repo = repo;
        }

        // GET: api/BeerRecipe
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/BeerRecipe/5
        public BeerRecipeViewModel Get(int id)
        {
            var recipe = _repo.SelectById(id);
            BeerRecipeViewModel recipeVm = new BeerRecipeViewModel();
            MapRecipeModelToVM(recipeVm, recipe);
            return recipeVm;
        }

        // GET: api/BeerRecipe/"beer name"
        public BeerRecipeViewModel Get(string name)
        {
            var recipe = _repo.SearchByName(name);
            BeerRecipeViewModel recipeVm = new BeerRecipeViewModel();
            MapRecipeModelToVM(recipeVm, recipe);
            return recipeVm;
        }

        // POST: api/BeerRecipe
        public void Post([FromBody]BeerRecipeViewModel recipeVm)
        {
            var recipe = new Recipe();
            MapRecipeVmToModel(recipe, recipeVm);
            _repo.Insert(recipe);
        }

        // PUT: api/BeerRecipe/5
        public void Put(int id, [FromBody]BeerRecipeViewModel value)
        {
        }

        // DELETE: api/BeerRecipe/5
        public void Delete(int id)
        {
        }


        private void MapRecipeVmToModel(Recipe recipe, BeerRecipeViewModel recipeVm)
        {
            recipe.Id = recipeVm.Id;
            recipe.BeerType = recipeVm.BeerType;
            recipe.Name = recipeVm.Name;
            recipe.Description = recipeVm.Description;
            recipe.Ingredients =
                recipeVm.Ingredients.Select(
                    i =>
                        new RecipeIngredient()
                        {
                            Id = 0,
                            IngredientId = i.IngredientId,
                            RecipeId = recipeVm.Id,
                            Quantity = i.Quantity
                        }).ToList();

        }

        private void MapRecipeModelToVM(BeerRecipeViewModel recipeVm, Recipe recipe )
        {
            recipeVm.Id = recipe.Id;
            recipeVm.BeerType = recipe.BeerType;
            recipeVm.Name = recipe.Name;
            recipeVm.Description = recipe.Description;
            recipeVm.Ingredients =
                recipe.Ingredients.Select(
                    i =>
                        new RecipeIngredientVm()
                        {
                            Id = 0,
                            IngredientId = i.IngredientId,
                            RecipeId = recipeVm.Id,
                            Quantity = i.Quantity
                        }).ToList();

        }


    }
}
