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
    public class IngredientController : ApiController
    {
        private IGenericRepository<Ingredient> _repo;
        public IngredientController(IGenericRepository<Ingredient> repo)
        {
            _repo = repo;
        }

        // GET: api/Ingredient
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ingredient/5
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Ingredient/5
        public IngredientViewModel Get(string name)
        {
            var ingredient = _repo.SearchByName(name);
            return MapIngredientToVM(ingredient);
        }

        // POST: api/Ingredient
        public void Post([FromBody]IngredientViewModel value)
        {
            _repo.Insert(MapVmToIngredient(value));
        }

        // PUT: api/Ingredient/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ingredient/5
        public void Delete(int id)
        {
        }


        private IngredientViewModel MapIngredientToVM(Ingredient ingredient)
        {
            return new IngredientViewModel()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Description = ingredient.Description,
                Units = ingredient.Units
            };

        }

        private Ingredient MapVmToIngredient(IngredientViewModel ingredient)
        {
            return new Ingredient()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Description = ingredient.Description,
                Units = ingredient.Units
            };

        }


    }
}
