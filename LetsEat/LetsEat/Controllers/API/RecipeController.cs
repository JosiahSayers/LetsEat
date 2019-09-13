using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Providers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers.API
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeDAL recipeDAL;
        private readonly IAuthProvider authProvider;

        public RecipeController(IRecipeDAL recipeDAL, IAuthProvider authProvider)
        {
            this.recipeDAL = recipeDAL;
            this.authProvider = authProvider;
        }

        [HttpPost]
        public IActionResult Post(Recipe recipe)
        {
            IActionResult output = Unauthorized();

            if (authProvider.IsLoggedIn)
            {
                recipe.UserWhoAdded = authProvider.GetCurrentUser();
                recipe.DateAdded = DateTime.Now;
                recipe.ImageLocations = recipe.ImageLocations == null ? new List<string>() : recipe.ImageLocations;

                output = StatusCode(200, recipeDAL.AddRecipe(recipe));
            }

            return output;
        }

        [HttpPut]
        public IActionResult Put(Recipe updatedRecipe)
        {
            Recipe currentRecipeFromDatabase = recipeDAL.GetRecipeByID(updatedRecipe.ID);
            IActionResult output = Unauthorized();

            if (authProvider.IsLoggedIn)
            {
                if (currentRecipeFromDatabase.UserWhoAdded.Id == authProvider.GetCurrentUser().Id)
                {
                    recipeDAL.Update(updatedRecipe);
                    output = Ok();
                }
            }

            return output;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Recipe recipeToDelete = recipeDAL.GetRecipeByID(id);
            IActionResult output = Unauthorized();

            if (authProvider.IsLoggedIn)
            {
                if (recipeToDelete.UserWhoAdded.Id == authProvider.GetCurrentUser().Id)
                {
                    recipeDAL.Delete(id);
                    return Ok();
                }
            }

            return output;
        }
    }
}
