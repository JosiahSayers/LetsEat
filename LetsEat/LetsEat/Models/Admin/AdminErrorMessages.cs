using System;
namespace LetsEat.Models.Admin
{
    public class AdminErrorMessages : BaseError
    {
        public Error NotAdmin
        {
            get
            {
                return this.ErrorResult("Insufficient permissions");
            }
        }

        public Error AdminError
        {
            get
            {
                return this.ErrorResult("Error on admin api endpoint");
            }
        }

        public Error CompleteWebsiteRequest
        {
            get
            {
                return this.ErrorResult("Error completing website request");
            }
        }

        public Error NotFound
        {
            get
            {
                return this.ErrorResult("That website request was not found");
            }
        }

        public Error DenyWebsiteRequest
        {
            get
            {
                return this.ErrorResult("Error denying website request");
            }
        }
    }
}
