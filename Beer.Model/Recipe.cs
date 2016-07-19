using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Model
{
    public class Recipe : RepositoryObject
    {
        public string BeerType { get; set; }
        //public BeerType BeerType { get; set; }
        public string Description { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }

    }
}
