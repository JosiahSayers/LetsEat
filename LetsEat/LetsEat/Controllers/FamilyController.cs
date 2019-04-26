using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Providers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers
{
    public class FamilyController : Controller
    {
        IFamilyDAL familyDAL;
        IAuthProvider authProvider;

        public FamilyController(IFamilyDAL familyDAL, IAuthProvider authProvider)
        {
            this.familyDAL = familyDAL;
            this.authProvider = authProvider;
        }

        public IActionResult Index()
        {
            if (authProvider.IsLoggedIn)
            {
                Family currentFamily = familyDAL.GetFamily(authProvider.GetCurrentUser().FamilyId);
                return View(currentFamily);
            }
            else
            {
                return View("Login", "Account");
            }
        }
    }
}