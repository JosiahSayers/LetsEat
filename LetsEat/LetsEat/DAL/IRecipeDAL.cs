﻿using System;
using System.Collections.Generic;
using LetsEat.Models;
using LetsEat.Models.RecipeBook;

namespace LetsEat.DAL
{
    public interface IRecipeDAL
    {
        Recipe GetRecipeByID(int id);
        List<Recipe> GetMyRecipes(int userId);
        Recipe AddRecipe(Recipe recipe);
        List<Recipe> SearchForRecipe(string searchQuery);
        SearchResults NewSearch(string searchQuery);
        List<Recipe> GetFamilyRecipes(int familyId);
        bool Delete(int id);
        bool Update(Recipe recipe);
    }
}
