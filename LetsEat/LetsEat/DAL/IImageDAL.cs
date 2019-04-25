using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IImageDAL
    {
        List<string> GetImageLocationsForRecipe(int recipeID);
        List<string> GetImageLocationsForRecipe(int recipeID, SqlConnection conn);

        bool AssignImageLocationToRecipe(string imgLoc, Recipe recipe);
    }
}
