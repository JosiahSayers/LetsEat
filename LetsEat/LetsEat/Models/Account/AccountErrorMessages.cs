using Microsoft.AspNetCore.Mvc;

namespace LetsEat.Models.Account
{
    public class AccountErrorMessages : BaseError
    {
        public Error LoginError
        {
            get
            {
                return this.ErrorResult("Login Error");
            }
        }

        public Error PasswordChange
        {
            get
            {
                return this.ErrorResult("Password Change Error");
            }
        }

        public Error PasswordMismatch
        {
            get
            {
                return this.ErrorResult("Passwords did not match");
            }
        }

        public Error NotLoggedIn
        {
            get
            {
                return this.ErrorResult("No user currently logged in, please log in before completing this action");
            }
        }

        public Error ChangeFamily
        {
            get
            {
                return this.ErrorResult("Change Family Error");
            }
        }

        public Error NoFamilyInvite
        {
            get
            {
                return this.ErrorResult("User must have an active invite to change families from this endpoint");
            }
        }

        public Error DeleteInvite
        {
            get
            {
                return this.ErrorResult("Delete Invite Error");
            }
        }
    }
}