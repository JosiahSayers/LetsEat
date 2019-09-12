using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LetsEat.Models;

namespace LetsEat.DAL.SQL
{
    public interface IIngredientDAL
    {
        List<string> GetIngredientsForRecipe(Recipe recipe);
        List<string> GetIngredientsForRecipe(Recipe recipe, SqlConnection conn);

        List<string> GetIngredientsForRecipe(int recipeID);
        List<string> GetIngredientsForRecipe(int recipeID, SqlConnection conn);

        int AddNewIngredient(string ingredient, Recipe recipe);
        int AddNewIngredient(string ingredient, int recipeID);
        void UpdateIngredients(int recipeId, List<string> ingredients, SqlConnection conn);
    }
}
