using System;
using System.Collections.Generic;
using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IImageDAL
    {
        List<string> GetImageLocationsForRecipe(int recipeID);
        bool AssignImageLocationToRecipe(string imgLoc, Recipe recipe);
    }
}
