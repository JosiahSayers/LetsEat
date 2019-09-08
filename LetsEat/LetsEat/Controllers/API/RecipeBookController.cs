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
    [Route("api/RecipeBook/[action]")]
    [ApiController]
    public class RecipeBookApiController : Controller
    {
        private readonly IRecipeDAL recipeDAL;
        private readonly IAuthProvider authProvider;
        private readonly IWebsiteRequestDAL websiteRequestDAL;
        private readonly EmailProvider emailProvider;
        private readonly RecipeBookErrorMessages error = new RecipeBookErrorMessages();

        public RecipeBookApiController(IRecipeDAL recipeDAL, IAuthProvider authProvider, IWebsiteRequestDAL websiteRequestDAL, EmailProvider emailProvider)
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
                output = StatusCode(200,
                    new RecipeBookModel(recipeDAL.GetMyRecipes(authProvider.GetCurrentUser().Id))
                );
            }
            else
            {
                output = StatusCode(500, error.NotLoggedIn);
            }

            return output;
        }

        [HttpGet]
        public IActionResult FamilyRecipes()
        {
            ObjectResult output = StatusCode(500, error.FamilyRecipes);

            if (authProvider.IsLoggedIn)
            {
                User user = authProvider.GetCurrentUser();

                if (user.FamilyId <= 1)
                {
                    output = StatusCode(500, error.NotInFamily);
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
                output = StatusCode(500, error.NotLoggedIn);
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
        [ValidateAntiForgeryToken]
        public IActionResult ManuallyAddRecipe(AddRecipeForm form)
        {
            if (authProvider.IsLoggedIn)
            {
                Recipe r = new Recipe()
                {
                    Name = form.Name,
                    Description = form.Description,
                    DateAdded = DateTime.Now,
                    Source = form.Source,
                    PrepMinutes = form.PrepMinutes,
                    CookMinutes = form.CookMinutes,
                    UserWhoAdded = authProvider.GetCurrentUser(),

                    Steps = form.ParseSteps(),
                    ImageLocations = form.ParseImageLocations(),
                    Ingredients = form.ParseIngredients()
                };

                if (recipeDAL.AddRecipe(r) != null)
                {
                    return View("Recipe", r);
                }
                else
                {
                    return View("Error");
                }

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ParseUrl(ParseURLForm form)
        {
            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();

                if (form.IsSupportedWebsite())
                {
                    Recipe newRecipe = form.Parse();
                    newRecipe.UserWhoAdded = currentUser;
                    newRecipe = recipeDAL.AddRecipe(newRecipe);

                    if (newRecipe != null)
                    {
                        return RedirectToAction("Recipe", new { id = newRecipe.ID });
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    WebsiteRequest wr = form.GenerateWebsiteRequest();
                    wr.User = currentUser;
                    websiteRequestDAL.AddNewWebsiteRequest(wr);

                    emailProvider.NewWebsiteRequest(wr);


                    return View("WebsiteRequestAdded", wr);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Recipe model = recipeDAL.GetRecipeByID(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            //todo: create update method in recipeDAL
            return RedirectToAction("Recipe", new { id = recipe.ID });
        }

        //todo: delete a recipe
    }
}
