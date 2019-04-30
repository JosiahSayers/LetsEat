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
    public class AdminController : Controller
    {
        private readonly IWebsiteRequestDAL websiteRequestDAL;
        private readonly EmailProvider emailProvider;
        private readonly IAuthProvider authProvider;
        public AdminController(IWebsiteRequestDAL websiteRequestDAL, EmailProvider emailProvider, IAuthProvider authProvider)
        {
            this.websiteRequestDAL = websiteRequestDAL;
            this.emailProvider = emailProvider;
            this.authProvider = authProvider;
        }

        public IActionResult Index()
        {
            List<WebsiteRequest> wr = websiteRequestDAL.GetNewWebsiteRequests();

            return View(wr);
        }

        public IActionResult CompleteWebsiteRequest(int wrid)
        {
            WebsiteRequest wr = websiteRequestDAL.Get(wrid);

            websiteRequestDAL.Delete(wr.Id);

            emailProvider.WebsiteRequestComplete(wr);

            return View(wr);
        }

        public IActionResult DenyWebsiteRequest(int wrid)
        {
            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();

                if (currentUser.IsAdmin)
                {
                    DenyWebsiteRequest model = new DenyWebsiteRequest()
                    {
                        WebsiteRequest = websiteRequestDAL.Get(wrid),
                        Admin = currentUser
                    };

                    return View(model);
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Login", "Account");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DenyWebsiteRequest(DenyWebsiteRequest model)
        {
            if (authProvider.IsLoggedIn)
            {
                User currentUser = authProvider.GetCurrentUser();

                if (currentUser.IsAdmin)
                {
                    websiteRequestDAL.Delete(model.WebsiteRequest.Id);

                    emailProvider.WebsiteRequestDenied(model);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Login", "Account");
            }
        }


        //todo: Add controller for denying request

        //todo: Add ability for program to email a user when their request is denied, along with a custom message from the admin



    }
}