using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Model;

namespace Beer.Data
{
    public class RecipeRepository : IGenericRepository<Recipe>
    {
        private List<Recipe> _recipes;
        private List<RecipeIngredient> _recipeIngredients;

        public RecipeRepository()
        {
            _recipes = new List<Recipe>();
            _recipeIngredients = new List<RecipeIngredient>();
        }
        public IEnumerable<Recipe> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Recipe SelectById(object id)
        {
            throw new NotImplementedException();
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
