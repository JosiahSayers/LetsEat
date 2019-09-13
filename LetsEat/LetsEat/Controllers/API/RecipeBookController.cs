using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.Forms;
using LetsEat.Models.RecipeBook;
using LetsEat.Providers.Auth;
using LetsEat.Providers.Email;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers.API
{
    [Route("api/v1/RecipeBook/[action]")]
    [ApiController]
    public class RecipeBookApiController : Controller
    {
        private readonly IRecipeDAL recipeDAL;
        private readonly ApiAuthProvider authProvider;
        private readonly IWebsiteRequestDAL websiteRequestDAL;
        private readonly EmailProvider emailProvider;
        private readonly RecipeBookErrorMessages error = new RecipeBookErrorMessages();

        public RecipeBookApiController(IRecipeDAL recipeDAL, ApiAuthProvider authProvider, IWebsiteRequestDAL websiteRequestDAL, EmailProvider emailProvider)
        {
            this.recipeDAL = recipeDAL;
            this.authProvider = authProvider;
            this.websiteRequestDAL = websiteRequestDAL;
            this.emailProvider = emailProvider;
        }

        [HttpGet]
        public IActionResult MyRecipes()
        {
            ObjectResult output = StatusCode(500, error.MyRecipes);

            if (authProvider.IsLoggedIn)
            {
                List<Recipe> myRecipes = recipeDAL.GetMyRecipes(authProvider.GetCurrentUser().Id);

                if (myRecipes != null)
                {
                    output = StatusCode(200,
                        new RecipeBookModel(recipeDAL.GetMyRecipes(authProvider.GetCurrentUser().Id))
                    );
                }
            }
            else
            {
                output = StatusCode(401, error.NotLoggedIn);
            }

            return output;
        }

        [HttpGet]
        public IActionResult FamilyRecipes()
        {
            ObjectResult output;

            if (authProvider.IsLoggedIn)
            {
                User user = authProvider.GetCurrentUser();

                if (user.FamilyId <= 1)
                {
                    output = StatusCode(401, error.NotInFamily);
                }
                else
                {
                    output = StatusCode(200,
                        new RecipeBookModel(recipeDAL.GetFamilyRecipes(user.FamilyId))
                    );
                }
            }
            else
            {
                output = StatusCode(401, error.NotLoggedIn);
            }

            return output;
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            // Todo: Implement search restrictions to only recipes in your family book
            ObjectResult output = StatusCode(200, recipeDAL.NewSearch(query));
            return output;
        }

        [HttpPost]
        public IActionResult ParseUrl(ParseURLForm form)
        {
            ObjectResult output = StatusCode(500, error.ParseUrl);

            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser(true);

                if (form.IsSupportedWebsite())
                {
                    Recipe newRecipe = form.Parse();
                    newRecipe.UserWhoAdded = currentUser;
                    newRecipe = recipeDAL.AddRecipe(newRecipe);

                    if (newRecipe != null)
                    {
                        output = StatusCode(200, newRecipe);
                    }
                }
                else
                {
                    WebsiteRequest wr = form.GenerateWebsiteRequest();
                    wr.User = currentUser;
                    websiteRequestDAL.AddNewWebsiteRequest(wr);

                    emailProvider.NewWebsiteRequest(wr);


                    output = StatusCode(501, wr);
                }
            }
            else
            {
                output = StatusCode(401, error.NotLoggedIn);
            }

            return output;
        }
    }
}
