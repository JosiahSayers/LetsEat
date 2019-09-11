using System;
using System.Collections.Generic;
using System.Linq;
using LetsEat.DAL;
using LetsEat.Models;
using Microsoft.AspNetCore.Http;

namespace LetsEat.Providers.Auth
{
    public class ApiAuthProvider : IAuthProvider
    {
        private Dictionary<string, string> signedInUsers = new Dictionary<string, string>();
        private IHttpContextAccessor contextAccessor;
        private IUsersDAL userDAL;
        private IWebsiteRequestDAL websiteRequestDAL;

        public ApiAuthProvider(IHttpContextAccessor contextAccessor, IUsersDAL userDAL, IWebsiteRequestDAL websiteRequestDAL)
        {
            this.contextAccessor = contextAccessor;
            this.userDAL = userDAL;
            this.websiteRequestDAL = websiteRequestDAL;
        }

        public bool IsLoggedIn => !String.IsNullOrEmpty(signedInUsers[SessionKeyFromCookies()]);

        public bool SignIn(string email, string password)
        {
            var user = userDAL.GetUser(email);
            var hashProvider = new HashProvider();

            if (user != null && hashProvider.VerifyPasswordMatch(user.Password, password, user.Salt))
            {
                this.signedInUsers[SessionKeyFromCookies()] = user.Email;
                return true;
            }

            return false;
        }

        public bool LogOff()
        {
            bool output = true;
            try
            {
                this.signedInUsers.Remove(SessionKeyFromCookies());
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool ChangePassword(string existingPassword, string newPassword)
        {
            var hashProvider = new HashProvider();
            var user = GetCurrentUser();

            // Confirm existing password match
            if (user != null && hashProvider.VerifyPasswordMatch(user.Password, existingPassword, user.Salt))
            {
                // Hash new password
                var newHash = hashProvider.HashPassword(newPassword);
                user.Password = newHash.Password;
                user.Salt = newHash.Salt;

                // Save into the db
                userDAL.UpdateUser(user);

                return true;
            }

            return false;
        }

        public User GetCurrentUser(bool isForApi = false)
        {
            var email = this.signedInUsers[SessionKeyFromCookies()];
            User output = null;

            if (!String.IsNullOrEmpty(email))
            {
                output = userDAL.GetUser(email);

                if (isForApi == true)
                {
                    output.Password = null;
                    output.Salt = null;
                }
            }

            return output;
        }

        public bool Register(string displayName, string email, string password, string role)
        {

            if (userDAL.DoesEmailAlreadyExist(email))
            {
                return false;
            }

            bool result = false;
            var hashProvider = new HashProvider();
            var passwordHash = hashProvider.HashPassword(password);

            var user = new User
            {
                DisplayName = displayName,
                Email = email,
                Password = passwordHash.Password,
                Salt = passwordHash.Salt,
                Role = role
            };

            result = userDAL.CreateUser(user);
            this.signedInUsers[SessionKeyFromCookies()] = user.Email;
            return result;
        }

        public bool UserHasRole(string[] roles)
        {
            var user = GetCurrentUser();
            return (user != null) &&
                roles.Any(r => r.ToLower() == user.Role.ToLower());
        }

        public bool IsAdmin()
        {
            return GetCurrentUser().IsAdmin;
        }

        public bool WebsiteRequestExists()
        {
            if (IsLoggedIn && IsAdmin())
            {
                return websiteRequestDAL.WebsiteRequestExists() == true;
            }

            return false;
        }

        private string SessionKeyFromCookies()
        {
            string sessionKey;
            bool keyFound = contextAccessor.HttpContext.Request.Cookies.TryGetValue(".AspNetCore.Session", out sessionKey);
            return keyFound ? sessionKey : null;
        }
    }
}
