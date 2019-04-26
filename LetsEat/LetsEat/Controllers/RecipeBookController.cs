using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.Forms;
using LetsEat.Providers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers
{
    public class RecipeBookController : Controller
    {
        private readonly IRecipeDAL recipeDAL;
        private readonly IAuthProvider authProvider;
        private readonly IWebsiteRequestDAL websiteRequestDAL;

        public RecipeBookController(IRecipeDAL recipeDAL, IAuthProvider authProvider, IWebsiteRequestDAL websiteRequestDAL)
        {
            this.recipeDAL = recipeDAL;
            this.authProvider = authProvider;
            this.websiteRequestDAL = websiteRequestDAL;
        }

        public IActionResult Index()
        {
            if (authProvider.IsLoggedIn)
            {
                List<Recipe> output = recipeDAL.GetMyRecipes(authProvider.GetCurrentUser().Id);
                return View(output);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Recipe(int id)
        {
            if (id > 0 && authProvider.IsLoggedIn)
            {
                Recipe recipe = recipeDAL.GetRecipeByID(id);

                User current = authProvider.GetCurrentUser();

                if (authProvider.GetCurrentUser().Id == recipe.UserWhoAdded.Id)
                {
                    return View(recipe);
                }
            }
            return NotFound();
        }

        public IActionResult Search(string id)
        {
            // Todo: Implement search restrictions to only recipes in your family book
            List<Recipe> model = recipeDAL.SearchForRecipe(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            if (authProvider.IsLoggedIn)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRecipe(AddRecipeForm form)
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

        [HttpGet]
        public IActionResult ParseURL()
        {
            if (authProvider.IsLoggedIn)
            {
                return View("ParseURL");
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
                if (form.IsSupportedWebsite())
                {
                    Recipe newRecipe = form.Parse();
                    newRecipe.UserWhoAdded = authProvider.GetCurrentUser();
                    newRecipe = recipeDAL.AddRecipe(newRecipe);

                    if (newRecipe != null)
                    {
                        return RedirectToAction("Recipe", new { id = newRecipe.ID});
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    WebsiteRequest wr = form.GenerateWebsiteRequest();
                    wr.user = authProvider.GetCurrentUser();
                    websiteRequestDAL.AddNewWebsiteRequest(wr);
                    return View("WebsiteRequestAdded", wr);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
