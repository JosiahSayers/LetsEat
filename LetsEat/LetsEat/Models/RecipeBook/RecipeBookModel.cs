using System;
using System.Collections.Generic;

namespace LetsEat.Models.RecipeBook
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
