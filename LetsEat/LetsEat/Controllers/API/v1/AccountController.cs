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

namespace LetsEat.Controllers.API.v1
{
    [Route("api/v1/account/[action]")]
    [ApiController]
    public class AccountApiController : Controller
    {
        private readonly IAuthProvider authProvider;
        private readonly IUsersDAL userDAL;
        private readonly EmailProvider emailProvider;
        private readonly IFamilyDAL familyDAL;
        private readonly AccountErrorMessages error = new AccountErrorMessages();

        public AccountApiController(ApiAuthProvider authProvider, IUsersDAL userDAL, EmailProvider emailProvider, IFamilyDAL familyDAL)
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

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
          ObjectResult output = StatusCode(500, error.LoginError);
            // Ensure the fields were filled out
            if (ModelState.IsValid)
            {
                // Check that they provided correct credentials
                bool validLogin = authProvider.SignIn(loginViewModel.Email, loginViewModel.Password);
                if (validLogin)
                {
                    output = StatusCode(200, authProvider.GetCurrentUser(true));
                }
            }

            return output;
        }

        [HttpGet]
        public IActionResult LogOff()
        {
            // Clear user from session
            bool loggedOut = authProvider.LogOff();
            return loggedOut ? Ok() : StatusCode(500);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid && !userDAL.DoesEmailAlreadyExist(rvm.Email))
            {
                // Register them as a new user (and set default role in db schema)
                // When a user registeres they need to be given a role. If you don't need anything special
                // just give them "User".
                if (authProvider.Register(rvm.DisplayName, rvm.Email, rvm.Password, role: "User") == false)
                {
                    return StatusCode(500);
                }

                emailProvider.Welcome(userDAL.GetUser(rvm.Email));

                // Redirect the user where you want them to go after registering
                return StatusCode(200, authProvider.GetCurrentUser());
            }

            return View(rvm);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel cpvm)
        {
            ObjectResult output = authProvider.IsLoggedIn ? StatusCode(500, error.PasswordChange) : StatusCode(500, error.NotLoggedIn);

            if (ModelState.IsValid)
            {
                if (authProvider.ChangePassword(cpvm.OldPassword, cpvm.ConfirmPassword))
                {
                    output = StatusCode(200, authProvider.GetCurrentUser(true));
                }
            }
            else if (cpvm.NewPassword != cpvm.ConfirmPassword)
            {
                output = StatusCode(500, error.PasswordMismatch);
            }

            return output;
        }

        [HttpPost]
        public IActionResult ChangeFamily(User user)
        {
            ObjectResult output = StatusCode(500, error.ChangeFamily);

            user = userDAL.GetUser(user.Email);

            if (String.IsNullOrEmpty(user.FamilyRole))
            {
                user.FamilyRole = "Member";
            }

            if (user.Invite.FamilyId <= 1)
            {
                output = StatusCode(500, error.NoFamilyInvite);
            }
            else
            {
                user.FamilyId = user.Invite.FamilyId;

                if (userDAL.ChangeFamily(user))
                {
                    output = StatusCode(200, authProvider.GetCurrentUser());

                    InviteResponse ir = new InviteResponse()
                    {
                        Invitee = user,
                        Inviter = user.Invite.InvitedBy,
                        Family = familyDAL.GetFamily(user.FamilyId)
                    };

                    emailProvider.AcceptInvite(ir);
                }
            }

            return output;
        }

        [HttpPost]
        public IActionResult DeleteInvite(User user)
        {
            user = userDAL.GetUser(user.Email);
            ObjectResult output = StatusCode(500, error.DeleteInvite);

            if (user != null)
            {
                if (userDAL.DeleteInvite(user))
                {
                    output = StatusCode(200, authProvider.GetCurrentUser());

                    InviteResponse ir = new InviteResponse()
                    {
                        Invitee = user,
                        Inviter = user.Invite.InvitedBy,
                        Family = familyDAL.GetFamily(user.Invite.FamilyId)
                    };

                    emailProvider.DeclineInvite(ir);
                }
            }

            return output;
        }

        [HttpPost]
        public IActionResult ValidateLogin()
        {
            StatusCodeResult output = StatusCode(401);

            if (authProvider.IsLoggedIn)
            {
                output = StatusCode(200);
            }

            return output;
        }
    }
}
