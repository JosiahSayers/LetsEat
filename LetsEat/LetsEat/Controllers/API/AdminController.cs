using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.Admin;
using LetsEat.Models.Forms;
using LetsEat.Providers.Auth;
using LetsEat.Providers.Email;
using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Controllers.Api
{
    [Route("api/Admin/[action]")]
    [ApiController]
    public class AdminApiController : Controller
    {
        private readonly IWebsiteRequestDAL websiteRequestDAL;
        private readonly EmailProvider emailProvider;
        private readonly IAuthProvider authProvider;
        private readonly AdminErrorMessages error = new AdminErrorMessages();

        public AdminApiController(
            IWebsiteRequestDAL websiteRequestDAL,
            EmailProvider emailProvider,
            ApiAuthProvider authProvider
            )
        {
            this.websiteRequestDAL = websiteRequestDAL;
            this.emailProvider = emailProvider;
            this.authProvider = authProvider;
        }

        [HttpGet]
        public IActionResult WebsiteRequests()
        {
            ObjectResult output = StatusCode(500, error.AdminError);

            if (authProvider.IsAdmin())
            {
                List<WebsiteRequest> wr = websiteRequestDAL.GetNewWebsiteRequests();

                if (wr != null)
                {
                    output = StatusCode(200, new WebsiteRequestModel(wr));
                }
            }
            else
            {
                output = StatusCode(401, error.NotAdmin);
            }

            return output;
        }

        [HttpDelete]
        public IActionResult CompleteWebsiteRequest(int wrid)
        {
            EditWebsiteRequestModel outputModel = new EditWebsiteRequestModel();
            ObjectResult output = StatusCode(500, error.CompleteWebsiteRequest);

            if (authProvider.IsAdmin())
            {
                WebsiteRequest wr = websiteRequestDAL.Get(wrid);
                if (wr == null)
                {
                    output = StatusCode(404, error.NotFound);
                }
                else
                {
                    outputModel.SuccessfullyDeleted = websiteRequestDAL.Delete(wr.Id);

                    if (outputModel.SuccessfullyDeleted)
                    {
                        outputModel.EmailSent = emailProvider.WebsiteRequestComplete(wr);
                        output = StatusCode(200, outputModel);
                    }
                    else
                    {
                        output = StatusCode(500, outputModel);
                    }
                }
            }
            else
            {
                output = StatusCode(401, error.NotAdmin);
            }

            return output;
        }

        [HttpDelete]
        public IActionResult DenyWebsiteRequest(DenyWebsiteRequest inputModel)
        {
            EditWebsiteRequestModel outputModel = new EditWebsiteRequestModel();
            ObjectResult output = StatusCode(500, error.DenyWebsiteRequest);

            if (authProvider.IsAdmin())
            {
                WebsiteRequest wr = websiteRequestDAL.Get(inputModel.WebsiteRequest.Id);

                if (wr == null)
                {
                    output = StatusCode(404, error.NotFound);
                }
                else
                {
                    outputModel.SuccessfullyDeleted = websiteRequestDAL.Delete(wr.Id);

                    if (outputModel.SuccessfullyDeleted)
                    {
                        outputModel.EmailSent = emailProvider.WebsiteRequestDenied(inputModel);
                        output = StatusCode(200, outputModel);
                    }
                    else
                    {
                        output = StatusCode(500, outputModel);
                    }
                }
            }
            else
            {
                output = StatusCode(401, error.NotAdmin);
            }

            return output;
        }
    }
}
