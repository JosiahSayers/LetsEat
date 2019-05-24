using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IStepDAL
    {
        List<string> GetStepsForRecipe(int recipeID);
        List<string> GetStepsForRecipe(int recipeID, SqlConnection conn);
        bool AddStepsForRecipe(int stepNumber, string stepText, Recipe recipe);
        void UpdateStepsForRecipe(int recipeId, List<string> steps, SqlConnection conn);
    }
}
