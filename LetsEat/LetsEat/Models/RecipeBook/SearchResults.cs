using System;
using System.Collections;
using System.Collections.Generic;

namespace LetsEat.Models.RecipeBook
{
    public class SearchResults
    {
        public List<RecipeSearchResults> Recipes { get; set; }

        public SearchResults()
        {
            Recipes = new List<RecipeSearchResults>();
        }

        public SearchResults(List<RecipeSearchResults> recipes)
        {
            Recipes = recipes;
        }
    }
}
