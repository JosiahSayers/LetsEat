using System;
using System.Collections.Generic;
using LetsEat.Models.RecipeModels;

namespace LetsEat.Models.RecipeBookModels
{
    public class RecipeBookModel
    {
        public IEnumerable<Recipe> Recipes { get; }

        public RecipeBookModel(IEnumerable<Recipe> recipes)
        {
            Recipes = recipes;
        }
    }
}
