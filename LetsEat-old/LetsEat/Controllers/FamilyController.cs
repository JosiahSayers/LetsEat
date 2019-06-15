using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.Email;
using LetsEat.Models.FamilyController;
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

        [HttpGet]
        public IActionResult RemoveMember(int userIdToRemove)
        {
            User userToRemove = usersDAL.GetUser(userIdToRemove);

            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();
                if (currentUser.FamilyRole == "Leader" && currentUser.FamilyId == userToRemove.FamilyId)
                {
                    return View(userToRemove);
                }
                else
                {
                    return RedirectToAction("NotAllowed", "Family");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveMember(User userToRemove)
        {
            userToRemove = usersDAL.GetUser(userToRemove.Id);

            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();

                if (currentUser.FamilyRole == "Leader" && currentUser.FamilyId == userToRemove.FamilyId)
                {
                    RemoveFromFamilyEmail email = new RemoveFromFamilyEmail()
                    {
                        User = userToRemove,
                        Leader = currentUser,
                        Family = familyDAL.GetFamily(currentUser.FamilyId)
                    };

                    if (usersDAL.RemoveFromFamily(userToRemove))
                    {
                        emailProvider.RemoveFromFamily(email);
                    }
                }

                return RedirectToAction("Index", "Family");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult Leave()
        {
            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();
                Family family = familyDAL.GetFamily(currentUser.Id);
                List<User> familyLeaders = familyDAL.GetLeaders(currentUser.FamilyId);

                if(currentUser.FamilyRole == "Leader")
                {
                    if (familyLeaders.Count == 1 && family.Members.Count > 1 )
                    {
                        return View("FamilyNeedsALeader");
                    }
                    else
                    {
                        return View(currentUser);
                    }
                }
                return View(currentUser);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Leave(User user)
        {
            if (authProvider.IsLoggedIn && authProvider.GetCurrentUser().Id == user.Id)
            {
                User currentUser = authProvider.GetCurrentUser();

                usersDAL.RemoveFromFamily(user);
                
                Family family = familyDAL.GetFamily(currentUser.FamilyId);

                if(family.Members.Count == 0)
                {
                    familyDAL.Remove(currentUser.FamilyId);
                }

                return RedirectToAction("Index", "RecipeBook");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}