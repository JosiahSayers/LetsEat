using System;
namespace LetsEat.Models.Account
{
    public class IsEmailAvailableApiResponse
    {
        public string Email { get; }
        public bool IsAvailable { get; }

        public IsEmailAvailableApiResponse(string email, bool isAvailable)
        {
            Email = email;
            IsAvailable = isAvailable;
        }
    }
}
