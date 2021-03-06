﻿using System;
using System.Collections.Generic;
using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IWebsiteRequestDAL
    {
        List<WebsiteRequest> GetNewWebsiteRequests();
        bool AddNewWebsiteRequest(WebsiteRequest newRequest);
        bool? WebsiteRequestExists();

        WebsiteRequest Get(int id);
        bool Delete(int id);
    }
}
