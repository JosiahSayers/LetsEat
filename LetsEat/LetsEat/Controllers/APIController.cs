using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Providers.Auth;
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

        public APIController(IAuthProvider authProvider, IUsersDAL userDAL)
        {
            this.authProvider = authProvider;
            this.userDAL = userDAL;
        }
        //todo: check if user is logged in and has correct permissions in each action method
        public List<User> SearchForMemberToAdd(string email)
        {
            return userDAL.SearchForUsersNotInFamily(email);
        }

        public IActionResult InviteUserToFamily(int userId, int familyId)
        {
            //todo: check if user is currently in a family before adding an invite
            if(userDAL.InviteUserToFamily(userId, familyId))
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}