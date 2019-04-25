using System;
using System.Collections.Generic;
using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IStepDAL
    {
        List<string> GetStepsForRecipe(int recipeID);
        bool AddStepsForRecipe(int stepNumber, string stepText, Recipe recipe);
    }
}
