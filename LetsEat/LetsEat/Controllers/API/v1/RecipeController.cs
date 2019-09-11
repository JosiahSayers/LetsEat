using System;
using System.Collections.Generic;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.RecipeModels;
using LetsEat.Providers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers.API.v1
{
    [Route("api/v1/[controller]")]
    public class RecipeApiController : Controller
    {
        private readonly IRecipeDAL recipeDAL;
        private readonly IAuthProvider authProvider;
        private readonly RecipeErrorMessages error = new RecipeErrorMessages();

        public RecipeApiController(IRecipeDAL recipeDAL, IAuthProvider authProvider)
        {
            this.recipeDAL = recipeDAL;
            this.authProvider = authProvider;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Recipe recipe)
        {
            ObjectResult output = StatusCode(401, error.NotAuthorized);

            if (authProvider.IsLoggedIn)
            {
                recipe.UserWhoAdded = authProvider.GetCurrentUser();
                recipe.DateAdded = DateTime.Now;
                recipe.ImageLocations = recipe.ImageLocations == null ? new List<string>() : recipe.ImageLocations;

                Recipe newRecipe = recipeDAL.AddRecipe(recipe);

                if (newRecipe != null)
                {
                    output = StatusCode(200, newRecipe); 
                }
                else
                {
                    output = StatusCode(500, error.RecipeError);
                }
            }

            return output;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Recipe updatedRecipe)
        {
            ObjectResult output = StatusCode(401, error.NotAuthorized);

            if (authProvider.IsLoggedIn)
            {
                Recipe currentRecipe = recipeDAL.GetRecipeByID(id);

                if (CanAccessRecipe(currentRecipe, authProvider.GetCurrentUser()))
                {
                    if (recipeDAL.Update(updatedRecipe))
                    {
                        output = StatusCode(200, recipeDAL.GetRecipeByID(id));
                    }
                    else
                    {
                        output = StatusCode(500, error.RecipeError);
                    }
                }
            }
            recipeDAL.Update(updatedRecipe);

            return output;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ObjectResult output = StatusCode(401, error.NotAuthorized);

            if (authProvider.IsLoggedIn)
            {
                if (CanAccessRecipe(recipeDAL.GetRecipeByID(id), authProvider.GetCurrentUser()))
                {
                    if (recipeDAL.Delete(id))
                    {
                        output = StatusCode(200, error.Deleted);
                    }
                    else
                    {
                        output = StatusCode(500, error.RecipeError);
                    }
                }
            }
            else
            {
                output = StatusCode(401, error.NotLoggedIn);
            }
            return output;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ObjectResult output = StatusCode(401, error.NotAuthorized);

            if (authProvider.IsLoggedIn)
            {
                Recipe recipe = recipeDAL.GetRecipeByID(id);
                User currentUser = authProvider.GetCurrentUser();

                if (recipe == null || currentUser == null)
                {
                    output = StatusCode(500, error.RecipeError);
                }
                else
                {
                    if (CanAccessRecipe(recipe, currentUser))
                    {
                        output = StatusCode(200, recipe);
                    }
                }
            }
            else
            {
                output = StatusCode(401, error.NotLoggedIn);
            }

            return output;
        }

        private bool CanAccessRecipe(Recipe recipe, User user)
        {
            bool output = false;

            if ((user.Id == recipe.UserWhoAdded.Id) || (user.FamilyId == recipe.FamilyID))
            {
                output = true;
            }

            return output;
        }
    }
}
