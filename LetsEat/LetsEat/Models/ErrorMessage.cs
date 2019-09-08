using System;
using Microsoft.AspNetCore.Mvc;
using LetsEat.Models;

namespace LetsEat.Models
{
    public class BaseError
    {
        protected JsonResult JsonError(string errorMessage)
        {
            return new JsonResult(new Error(errorMessage));
        }

        protected Error ErrorResult(string errorMessage)
        {
            return new Error(errorMessage);
        }

        public Error NotLoggedIn
        {
            get
            {
                return ErrorResult("Not Logged In");
            }
        }
    }
}