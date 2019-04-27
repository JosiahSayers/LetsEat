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
    public class FamilyController : Controller
    {
        private readonly IFamilyDAL familyDAL;
        private readonly IAuthProvider authProvider;
        private readonly IUsersDAL usersDAL;

        public FamilyController(IFamilyDAL familyDAL, IAuthProvider authProvider, IUsersDAL usersDAL)
        {
            this.familyDAL = familyDAL;
            this.authProvider = authProvider;
            this.usersDAL = usersDAL;
        }

        public IActionResult Index()
        {
            if (authProvider.IsLoggedIn)
            {
                FamilyViewModel fvm = new FamilyViewModel();
                fvm.CurrentUser = authProvider.GetCurrentUser();
                fvm.Family = familyDAL.GetFamily(fvm.CurrentUser.FamilyId);

                return View(fvm);
            }
            else
            {
                return View("Login", "Account");
            }
        }

        public IActionResult AddMember()
        {
            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();
                if (currentUser.FamilyRole == "Leader")
                {
                    User newMember = new User()
                    {
                        FamilyId = currentUser.FamilyId,
                        FamilyRole = "Member"
                    };

                    AddFamilyMemberForm form = new AddFamilyMemberForm()
                    {
                        CurrentUser = currentUser,
                        NewMember = newMember
                    };
                    return View(form);
                }
                else
                {
                    return View("NotAllowed");
                }
            }
            else
            {
                return View("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult ChangeMemberRole(int userIdToChange)
        {
            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();
                if (currentUser.FamilyRole == "Leader")
                {
                    ChangeMemberRoleViewModel viewModel = new ChangeMemberRoleViewModel();
                    viewModel.userToChange = usersDAL.GetUser(userIdToChange);

                    return View(viewModel);
                }
                else
                {
                    return View("NotAllowed");
                }
            }
            else
            {
                return View("Login", "Account");
            }
        }
    }
}