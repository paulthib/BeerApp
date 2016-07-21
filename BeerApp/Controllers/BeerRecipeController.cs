using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
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
        public JsonResult<IEnumerable<BeerRecipeViewModel>> Get()
        {
            var recipe = _repo.SelectAll();
            var recipeVm = recipe.Select(r => MapToViewModel(r));
            return Json(recipeVm);
        }

        // GET: api/BeerRecipe/5
        public JsonResult<Recipe> Get(int id)
        {
            var recipe = _repo.SelectById(id);
            return Json(recipe);
        }


        // GET: api/BeerRecipe/"beer name"
        public BeerRecipeViewModel Get(string name)
        {
            var recipe = _repo.SearchByName(name);
            BeerRecipeViewModel recipeVm = new BeerRecipeViewModel();
            return MapToViewModel(recipe);
        }

        // POST: api/BeerRecipe
        public void Post([FromBody]BeerRecipeViewModel recipeVm)
        {
            var recipe = new Recipe();
            _repo.Insert(MapToModel(recipeVm));
        }

        // PUT: api/BeerRecipe/5
        public void Put(int id, [FromBody]BeerRecipeViewModel value)
        {
        }

        // DELETE: api/BeerRecipe/5
        public void Delete(int id)
        {
        }


        private Recipe MapToModel( BeerRecipeViewModel recipeVm)
        {
            Recipe recipe = new Recipe();
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

            return recipe;
        }

        private BeerRecipeViewModel MapToViewModel(Recipe recipe)
        {
            if (recipe == null) return null;
            BeerRecipeViewModel recipeVm = new BeerRecipeViewModel();
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

            return recipeVm;
        }
    }
}
