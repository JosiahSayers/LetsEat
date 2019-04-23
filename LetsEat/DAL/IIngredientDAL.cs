using System;
using System.Collections.Generic;
using LetsEat.Models;

namespace LetsEat.DAL.SQL
{
    public interface IIngredientDAL
    {
        List<string> GetIngredientsForRecipe(Recipe recipe);
        List<string> GetIngredientsForRecipe(int recipeID);
        int AddNewIngredient(string ingredient, Recipe recipe);
        int AddNewIngredient(string ingredient, int recipeID);
    }
}
