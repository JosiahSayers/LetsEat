using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LetsEat.Models.RecipeModels;

namespace LetsEat.DAL
{
    public interface IImageDAL
    {
        List<string> GetImageLocationsForRecipe(int recipeID);
        List<string> GetImageLocationsForRecipe(int recipeID, SqlConnection conn);
        bool AssignImageLocationToRecipe(string imgLoc, Recipe recipe);
        void UpdateImageLocationsForRecipe(int recipeId, List<string> imageLocations, SqlConnection conn);
        void Remove(int recipeId, string imageLocation);
    }
}
