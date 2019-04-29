using System;
using System.Collections.Generic;
using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IWebsiteRequestDAL
    {
        List<WebsiteRequest> GetNewWebsiteRequests();
        void AddNewWebsiteRequest(WebsiteRequest newRequest);
        bool? WebsiteRequestExists();
    }
}
