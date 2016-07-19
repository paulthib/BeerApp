using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeerApp.Models
{
    public class BeerRecipeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string BeerType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RecipeIngredientVm> Ingredients { get; set; }
    }

    public class RecipeIngredientVm
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
    }

}