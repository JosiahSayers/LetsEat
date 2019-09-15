using System;
namespace LetsEat.Models.Account
{
    public class SuccessfulLoginResponse
    {
        public ApiResponseUser User { get; set; }
        public string AccessToken { get; set; }

        public SuccessfulLoginResponse(User user, string accessToken)
        {
            User = new ApiResponseUser(user);
            AccessToken = accessToken;
        }

        public SuccessfulLoginResponse(User user)
        {
            User = new ApiResponseUser(user);
        }

        public SuccessfulLoginResponse(string accessToken)
        {
            AccessToken = accessToken;
        }

        public SuccessfulLoginResponse()
        {

        }
    }
}
