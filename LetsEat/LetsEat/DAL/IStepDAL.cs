using System;
using System.Collections.Generic;
using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IStepDAL
    {
        List<string> GetStepsForRecipe(int recipeID);
        List<string> GetStepsForRecipe(int recipeID, System.Data.SqlClient.SqlConnection conn);
        bool AddStepsForRecipe(int stepNumber, string stepText, Recipe recipe);
    }
}
