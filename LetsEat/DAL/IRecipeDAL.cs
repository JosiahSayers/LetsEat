﻿using System;
using System.Collections.Generic;
using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IRecipeDAL
    {
        Recipe GetRecipeByID(int id);
        List<Recipe> GetAllRecipes();
        int AddRecipe(Recipe recipe);
        List<Recipe> SearchForRecipe(string searchQuery);
    }
}
