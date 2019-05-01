using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.Models.Account;
using LetsEat.DAL;
using LetsEat.Providers.Auth;
using Microsoft.AspNetCore.Mvc;
using LetsEat.Models;
using LetsEat.Providers.Email;
using LetsEat.Models.Email;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsEat.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthProvider authProvider;
        private readonly IUsersDAL userDAL;
        private readonly EmailProvider emailProvider;
        private readonly IFamilyDAL familyDAL;

        public AccountController(IAuthProvider authProvider, IUsersDAL userDAL, EmailProvider emailProvider, IFamilyDAL familyDAL)
        {
            this.authProvider = authProvider;
            this.userDAL = userDAL;
            this.emailProvider = emailProvider;
            this.familyDAL = familyDAL;
        }

        //[AuthorizationFilter] // actions can be filtered to only those that are logged in -- or filtered to only those that have a certain role [array of roles]
        //
        // --> Checks if the role property attached to the user is in the given array --
        //      (defines user by grabbing the session key, which is set to be the email upon registration/login) --  
        // 
        // --> if user role not in given array, returns Status Code 403 as http result. 
        // --> if not logged in, there is no user, so no session key was set, which means none will be found. In this case, the http result will be a redirect to account/login. 
        //
        [AuthorizationFilter("Admin", "User")]
        [HttpGet]
        public IActionResult Index()
        {
            var user = authProvider.GetCurrentUser();
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            // Ensure the fields were filled out
            if (ModelState.IsValid)
            {
                // Check that they provided correct credentials
                bool validLogin = authProvider.SignIn(loginViewModel.Email, loginViewModel.Password);
                if (validLogin)
                {
                    // Redirect the user where you want them to go after successful login
                    return RedirectToAction("Index", "RecipeBook");
                }
            }

            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult LogOff()
        {
            // Clear user from session
            authProvider.LogOff();

            // Redirect the user where you want them to go after logoff
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid && !userDAL.DoesEmailAlreadyExist(rvm.Email))
            {
                // Register them as a new user (and set default role in db schema)
                // When a user registeres they need to be given a role. If you don't need anything special
                // just give them "User".
                if (authProvider.Register(rvm.DisplayName, rvm.Email, rvm.Password, role: "User") == false)
                {
                    return RedirectToAction("Error", "Home");
                }

                emailProvider.Welcome(userDAL.GetUser(rvm.Email));

                // Redirect the user where you want them to go after registering
                return RedirectToAction("Index", "Home");
            }

            return View(rvm);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel cpvm)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.ChangePassword(cpvm.OldPassword, cpvm.ConfirmPassword) == false)
                {
                    return RedirectToAction("Error", "Home");
                }

                //else
                return RedirectToAction("Index", "Account");
            }
            return View(cpvm);
        }

        [HttpPost]
        public IActionResult ChangeFamily(User user)
        {
            user = userDAL.GetUser(user.Email);

            if (String.IsNullOrEmpty(user.FamilyRole))
            {
                user.FamilyRole = "Member";
            }

            user.FamilyId = user.Invite.FamilyId;

            userDAL.ChangeFamily(user);

            InviteResponse ir = new InviteResponse()
            {
                Invitee = user,
                Inviter = user.Invite.InvitedBy,
                Family = familyDAL.GetFamily(user.FamilyId)
            };

            emailProvider.AcceptInvite(ir);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteInvite(User user)
        {
            user = userDAL.GetUser(user.Email);

            userDAL.DeleteInvite(user);

            InviteResponse ir = new InviteResponse()
            {
                Invitee = user,
                Inviter = user.Invite.InvitedBy,
                Family = familyDAL.GetFamily(user.Invite.FamilyId)
            };

            emailProvider.DeclineInvite(ir);

            return RedirectToAction("Index");
        }
    }
}
