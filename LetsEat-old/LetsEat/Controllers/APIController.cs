using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Providers.Auth;
using LetsEat.Providers.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IAuthProvider authProvider;
        private readonly IUsersDAL userDAL;
        private readonly EmailProvider emailProvider;
        private readonly IFamilyDAL familyDAL;
        private readonly IRecipeDAL recipeDAL;

        public APIController(IAuthProvider authProvider, IUsersDAL userDAL, EmailProvider emailProvider, IFamilyDAL familyDAL, IRecipeDAL recipeDAL)
        {
            this.authProvider = authProvider;
            this.userDAL = userDAL;
            this.emailProvider = emailProvider;
            this.familyDAL = familyDAL;
            this.recipeDAL = recipeDAL;
        }
        //todo: check if user is logged in and has correct permissions in each action method
        public List<User> SearchForMemberToAdd(string email)
        {
            if (authProvider.IsLoggedIn && authProvider.GetCurrentUser().FamilyRole == "Leader")
            {
                return userDAL.SearchForUsersNotInFamily(email);
            }
            else
            {
                return new List<User>();
            }
        }

        public IActionResult InviteUserToFamily(int userId, int familyId, int invited_by)
        {
            Invite invite = new Invite()
            {
                FamilyId = familyId,
                Invitee = userId,
                InvitedBy = new User()
                {
                    Id = invited_by
                }
            };

            if (userDAL.GetUser(userId).FamilyId == 0)
            {

                if (userDAL.InviteUserToFamily(invite))
                {
                    //todo: Email user when they receive an invite
                    emailProvider.Invite(userDAL.GetUser(userId), userDAL.GetUser(invited_by), familyDAL.GetFamily(familyId));
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return StatusCode(500);
            }
        }

    }
}