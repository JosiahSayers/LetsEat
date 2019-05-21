using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Providers.Auth;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsEat.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeDAL recipeDAL;
        private readonly IAuthProvider authProvider;

        public RecipeController(IRecipeDAL recipeDAL, IAuthProvider authProvider)
        {
            this.recipeDAL = recipeDAL;
            this.authProvider = authProvider;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public Recipe Post([FromBody]Recipe recipe)
        {
            Recipe error = new Recipe();
            error.ID = 0;
            if (authProvider.IsLoggedIn)
            {
                recipe.UserWhoAdded = authProvider.GetCurrentUser();
                recipe.DateAdded = DateTime.Now;
                recipe.ImageLocations = recipe.ImageLocations == null ? new List<string>() : recipe.ImageLocations;

                return recipeDAL.AddRecipe(recipe); 
            }
            else
            {
                return error;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
