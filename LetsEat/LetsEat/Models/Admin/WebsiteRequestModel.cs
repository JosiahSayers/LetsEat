using System;
using System.Collections.Generic;

namespace LetsEat.Models.Admin
{
    public class WebsiteRequestModel
    {
        public List<WebsiteRequest> WebsiteRequests { get; }

        public WebsiteRequestModel(List<WebsiteRequest> websiteRequests)
        {
            WebsiteRequests = websiteRequests;
        }
    }
}
