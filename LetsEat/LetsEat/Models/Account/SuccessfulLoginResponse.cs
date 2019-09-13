using System;
namespace LetsEat.Models.Account
{
    public class SuccessfulLoginResponse
    {
        public User User { get; set; }
        public string AccessToken { get; set; }

        public SuccessfulLoginResponse(User user, string accessToken)
        {
            User = user;
            AccessToken = accessToken;
        }

        public SuccessfulLoginResponse(User user)
        {
            User = user;
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
