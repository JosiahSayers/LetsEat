using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebsiteRequestDAL websiteRequestDAL;

        public AdminController(IWebsiteRequestDAL websiteRequestDAL)
        {
            this.websiteRequestDAL = websiteRequestDAL;
        }

        public IActionResult Index()
        {
            List<WebsiteRequest> wr = websiteRequestDAL.GetNewWebsiteRequests();

            return View(wr);
        }

        //todo: Add Controller for marking a request as complete

        //todo: Add controller for denying request

        //todo: Add ability for program to email a user when their request is either completed or denied, along with a custom message from the admin

        //todo: Add indicator to admin navbar when website requests exist

        //todo: Add ability for program to email admins when a new website request is added

    }
}