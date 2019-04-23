using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.Forms;
using LetsEat.Providers.Auth;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsEat.Controllers
{
    public class RecipeBookController : Controller
    {
        private readonly IRecipeDAL recipeDAL;
        private readonly IAuthProvider authProvider;

        public RecipeBookController(IRecipeDAL recipeDAL, IAuthProvider authProvider)
        {
            this.recipeDAL = recipeDAL;
            this.authProvider = authProvider;
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

                r.ID = recipeDAL.AddRecipe(r);

                return View("Recipe", r.ID);
            } else
            {
                return RedirectToAction("Login", "Account");
            }

        }
    }
}
