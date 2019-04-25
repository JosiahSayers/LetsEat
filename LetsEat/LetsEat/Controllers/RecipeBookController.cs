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
            return View();
        }

        public IActionResult List()
        {
            List<Recipe> recipes = recipeDAL.GetAllRecipes();

            return View(recipes);
        }

        public IActionResult Test()
        {
            List<Recipe> recipes = recipeDAL.GetAllRecipes();

            return Json(recipes);
        }

        public IActionResult Recipe(int id = 1)
        {
            Recipe recipe = recipeDAL.GetRecipeByID(id);

            return View(recipe);
        }

        public IActionResult Search(string id)
        {
            List<Recipe> model = recipeDAL.SearchForRecipe(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
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
            return View("ParseURL");
        }

        [HttpPost]
        public IActionResult ParseUrl(ParseURLForm form)
        {
            if (form.IsSupportedWebsite())
            {
                Recipe newRecipe = form.Parse();
                newRecipe.UserWhoAdded = authProvider.GetCurrentUser();
                newRecipe = recipeDAL.AddRecipe(newRecipe);

                if (newRecipe != null)
                {
                    return View("Recipe", newRecipe);
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                WebsiteRequest wr = form.GenerateWebsiteRequest();
                websiteRequestDAL.AddNewWebsiteRequest(wr);
                return View("WebsiteRequestAdded", wr);
            }
        }
    }
}
