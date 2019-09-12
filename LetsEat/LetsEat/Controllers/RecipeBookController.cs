using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.Forms;
using LetsEat.Providers.Auth;
using LetsEat.Providers.Email;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers
{
    public class RecipeBookController : Controller
    {
        private readonly IRecipeDAL recipeDAL;
        private readonly IAuthProvider authProvider;
        private readonly IWebsiteRequestDAL websiteRequestDAL;
        private readonly EmailProvider emailProvider;

        public RecipeBookController(IRecipeDAL recipeDAL, IAuthProvider authProvider, IWebsiteRequestDAL websiteRequestDAL, EmailProvider emailProvider)
        {
            this.recipeDAL = recipeDAL;
            this.authProvider = authProvider;
            this.websiteRequestDAL = websiteRequestDAL;
            this.emailProvider = emailProvider;
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

        public IActionResult Family()
        {
            if (authProvider.IsLoggedIn)
            {
                User user = authProvider.GetCurrentUser();

                if (user.FamilyId == 0)
                {
                    return View("NotInFamily");
                }
                else
                {
                    List<Recipe> recipes = recipeDAL.GetFamilyRecipes(user.FamilyId);
                    return View(recipes);
                }

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

                if (current.Id == recipe.UserWhoAdded.Id || current.FamilyId == recipe.FamilyID)
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

        [HttpGet]
        public IActionResult ManuallyAddRecipe()
        {
            if (authProvider.IsLoggedIn)
            {
                AddRecipeForm model = new AddRecipeForm();
                model.UserIdWhoAdded = authProvider.GetCurrentUser().Id;
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
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
