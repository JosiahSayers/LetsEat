using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LetsEat.Models;
using LetsEat.Providers.Auth;

namespace LetsEat.Controllers
{
    public class HomeController : Controller
    {
        private IAuthProvider authProvider;

        public HomeController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        public IActionResult Index()
        {
            if (authProvider.IsLoggedIn)
            {
                return RedirectToAction("Index", "RecipeBook");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
