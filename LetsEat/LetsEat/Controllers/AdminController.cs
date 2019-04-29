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
    }
}