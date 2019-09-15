using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using LetsEat.DAL;
using LetsEat.Models;
using LetsEat.Models.Account;
using Microsoft.AspNetCore.Http;

namespace LetsEat.Providers.Auth
{
    public class ApiAuthProvider : IAuthProvider
    {
        private int sessionKeyLength = 24;
        private Dictionary<string, User> loggedInUsers;
        private IUsersDAL usersDAL;
        private IWebsiteRequestDAL websiteRequestDAL;
        private readonly IHttpContextAccessor contextAccessor;


        public ApiAuthProvider(IUsersDAL usersDAL, IHttpContextAccessor contextAccessor, IWebsiteRequestDAL websiteRequestDAL)
        {
            loggedInUsers = new Dictionary<string, User>();
            this.usersDAL = usersDAL;
            this.contextAccessor = contextAccessor;
            this.websiteRequestDAL = websiteRequestDAL;
        }

        public bool IsLoggedIn {
            get
            {
                try
                {
                    return loggedInUsers[GetAccessTokenFromHeaders()] != null;
                }
                catch
                {
                    return false;
                }
            }
        }

        public User GetCurrentUser()
        {
            User currentUser = loggedInUsers[GetAccessTokenFromHeaders()];
            return currentUser;
        }

        public SuccessfulLoginResponse ApiSignIn(string email, string password)
        {
            SuccessfulLoginResponse output = null;
            var user = usersDAL.GetUser(email);
            var hashProvider = new HashProvider();

            if (user != null && hashProvider.VerifyPasswordMatch(user.Password, password, user.Salt))
            {
                if (IsUserSignedIn(user))
                {
                    RemoveUser(user);
                }

                string newAccessToken = GenerateAccessToken();
                loggedInUsers.Add(newAccessToken, user);
                output = new SuccessfulLoginResponse(user, newAccessToken);
            }

            return output;
        }

        public bool LogOff()
        {
            try
            {
                return loggedInUsers.Remove(GetAccessTokenFromHeaders());
            }
            catch
            {
                return false;
            }
        }

        public bool ChangePassword(string existingPassword, string newPassword)
        {
            var hashProvider = new HashProvider();
            var user = GetCurrentUser();

            if (user != null && hashProvider.VerifyPasswordMatch(user.Password, existingPassword, user.Salt))
            {
                var newHash = hashProvider.HashPassword(newPassword);
                user.Password = newHash.Password;
                user.Salt = newHash.Salt;

                usersDAL.UpdateUser(user);

                return true;
            }

            return false;
        }

        public bool Register(string displayName, string email, string password, string role)
        {
            if (usersDAL.DoesEmailAlreadyExist(email))
            {
                return false;
            }

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

            bool result = usersDAL.CreateUser(user);
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
            if(IsLoggedIn && IsAdmin())
            {
                return websiteRequestDAL.WebsiteRequestExists() == true;
            }

            return false;
        }

        public bool SignIn(string email, string password)
        {
            bool output = false;
            return output;
        }

        private string GenerateAccessToken()
        {
            byte[] randomBytes;
            string accessToken;
            do
            {
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                randomBytes = new byte[sessionKeyLength];
                crypto.GetBytes(randomBytes);
                accessToken = ConvertByteArrayToString(randomBytes);
            }
            while (DoesAccessTokenAlreadyExist(accessToken));

            return accessToken;
        }

        private bool DoesAccessTokenAlreadyExist(string accessToken)
        {
            return loggedInUsers.ContainsKey(accessToken);
        }

        private string GetAccessTokenFromHeaders()
        {
            return contextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        private string ConvertByteArrayToString(byte[] input)
        {
            string output = "";

            foreach(byte item in input)
            {
                output += item.ToString();
            }

            return output;
        }

        private bool IsUserSignedIn(User user)
        {
            return GetKeyByUser(user) != null;
        }

        private void RemoveUser(User user)
        {
            loggedInUsers.Remove(GetKeyByUser(user));
        }

        private string GetKeyByUser(User user)
        {
            string output = null;

            foreach (KeyValuePair<string, User> kvp in loggedInUsers)
            {
                if (kvp.Value.Id == user.Id)
                {
                    output = kvp.Key;
                }
            }

            return output;
        }
    }
}
