using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.Email;
using LetsEat.Models.Forms;
using LetsEat.Providers.Auth;
using LetsEat.Providers.Email;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers
{
    public class FamilyController : Controller
    {
        private readonly IFamilyDAL familyDAL;
        private readonly IAuthProvider authProvider;
        private readonly IUsersDAL usersDAL;
        private readonly EmailProvider emailProvider;

        public FamilyController(IFamilyDAL familyDAL, IAuthProvider authProvider, IUsersDAL usersDAL, EmailProvider emailProvider)
        {
            this.familyDAL = familyDAL;
            this.authProvider = authProvider;
            this.usersDAL = usersDAL;
            this.emailProvider = emailProvider;
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

        [HttpPost]
        public IActionResult ChangeMemberRole(ChangeMemberRoleViewModel vm)
        {
            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();
                if (currentUser.FamilyRole == "Leader")
                {
                    User userToUpdate = usersDAL.GetUser(vm.userToChange.Id);
                    if (userToUpdate.FamilyRole != vm.userToChange.FamilyRole)
                    {
                        FamilyRoleEmail emailModel = new FamilyRoleEmail()
                        {
                            PreviousRole = userToUpdate.FamilyRole,
                            UserWhoMadeChange = currentUser,
                            Family = familyDAL.GetFamily(userToUpdate.FamilyId)
                        };
                        userToUpdate.FamilyRole = vm.userToChange.FamilyRole;
                        emailModel.User = userToUpdate;

                        if (usersDAL.UpdateUser(userToUpdate))
                        {
                            emailProvider.FamilyRoleChanged(emailModel);
                        }
                    }

                    return RedirectToAction("Index");
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

        public IActionResult Create()
        {
            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();

                if (currentUser.FamilyId == 0)
                {
                    Family newFamily = new Family();
                    newFamily.Members = new List<User>();
                    newFamily.Members.Add(authProvider.GetCurrentUser());

                    return View(newFamily);
                }
                else
                {
                    return View("ConfirmChangeFamily");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Family newFamily)
        {
            if (authProvider.IsLoggedIn)
            {
                newFamily.Id = familyDAL.Create(newFamily);

                if (newFamily.Id > 0)
                {
                    User currentUser = authProvider.GetCurrentUser();

                    currentUser.FamilyId = newFamily.Id;
                    currentUser.FamilyRole = "Leader";

                    usersDAL.UpdateUser(currentUser);

                    return RedirectToAction("Index");
                }
                else
                {
                    // todo: an error occured. You should do something about it.
                    return View("Create", newFamily);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}