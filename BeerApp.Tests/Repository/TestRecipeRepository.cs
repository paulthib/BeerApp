using System;
using System.Collections.Generic;
using System.Linq;
using Beer.Data;
using Beer.Model;

namespace BeerApp.Tests.Repository
{
    public class TestRecipeRepository : IGenericRepository<Recipe>
    {
        private List<Recipe> _recipes;
        private List<RecipeIngredient> _recipeIngredients;

        public TestRecipeRepository()
        {
            _recipes = new List<Recipe>();
            _recipeIngredients = new List<RecipeIngredient>();

            // add a default
            List<RecipeIngredient> thisRecipeIngredients = new List<RecipeIngredient>();
            thisRecipeIngredients.Add(new RecipeIngredient() {Id = 1, IngredientId = 1, Quantity = 1, RecipeId = 1});
            _recipes.Add(new Recipe()
            {
                Id=1,Name = "Boldly Stout", Description = "a stout stout"
                , Ingredients = thisRecipeIngredients
            });
            _recipes.Add(new Recipe()
            {
                Id = 2,
                Name = "Polished Porter",
                Description = "another beer"
                ,
                Ingredients = thisRecipeIngredients
            });
        }
        public IEnumerable<Recipe> SelectAll()
        {
            return _recipes.ToList();
        }

        public Recipe SelectById(int id)
        {
            return _recipes.FirstOrDefault(r => r.Id == id);
        }

        public Recipe SearchByName(string name)
        {
            return _recipes.FirstOrDefault(r => r.Name == name);
        }

        public void Insert(Recipe recipe)
        {
            _recipes.Add(recipe);
            foreach (RecipeIngredient i in recipe.Ingredients)
            {
                _recipeIngredients.Add(
                    new RecipeIngredient()
                    {
                        RecipeId = recipe.Id,
                        IngredientId = i.IngredientId,
                        Quantity = i.Quantity
                    });
            }
        }

        public void Update(Recipe obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


    }
}
