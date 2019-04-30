using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Providers.Email;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebsiteRequestDAL websiteRequestDAL;
        private readonly EmailProvider emailProvider;
        public AdminController(IWebsiteRequestDAL websiteRequestDAL, EmailProvider emailProvider)
        {
            this.websiteRequestDAL = websiteRequestDAL;
            this.emailProvider = emailProvider;
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

        //todo: Add Controller for marking a request as complete

        //todo: Add controller for denying request

        //todo: Add ability for program to email a user when their request is either completed or denied, along with a custom message from the admin

        //todo: Add indicator to admin navbar when website requests exist

        //todo: Add ability for program to email admins when a new website request is added

    }
}