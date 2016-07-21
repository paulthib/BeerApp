using System;
using System.Collections.Generic;
using System.Linq;
using Beer.Model;

namespace Beer.Data
{
    public class IngredientRepository : IGenericRepository<Ingredient>
    {
        private List<Ingredient> _ingredients;

        public IngredientRepository()
        {
            _ingredients = new List<Ingredient>();
            _ingredients.Add(new Ingredient() { Id = 1, Name = "Cascade Hops" });
            _ingredients.Add(new Ingredient() { Id = 2, Name = "Barley" });
            _ingredients.Add(new Ingredient() { Id = 3, Name = "Wheat" });
            _ingredients.Add(new Ingredient() { Id = 4, Name = "Rye" });

        }
        public IEnumerable<Ingredient> SelectAll()
        {
            return _ingredients.ToList();
        }

        public Ingredient SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public Ingredient SearchByName(string name)
        {
            return _ingredients.FirstOrDefault(r => r.Name == name);
        }

        public void Insert(Ingredient obj)
        {
            _ingredients.Add(obj);
        }

        public void Update(Ingredient obj)
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
