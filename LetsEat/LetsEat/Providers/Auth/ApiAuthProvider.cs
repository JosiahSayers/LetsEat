using System;
using System.Collections.Generic;
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
        private readonly IHttpContextAccessor contextAccessor;


        public ApiAuthProvider(IUsersDAL usersDAL, IHttpContextAccessor contextAccessor)
        {
            loggedInUsers = new Dictionary<string, User>();
            this.usersDAL = usersDAL;
            this.contextAccessor = contextAccessor;
        }

        public bool IsLoggedIn => loggedInUsers[GetAccessTokenFromHeaders()] != null;

        public User GetCurrentUser(bool isForApi = true)
        {
            User currentUser = loggedInUsers[GetAccessTokenFromHeaders()];
            return currentUser;
        }

        public SuccessfulLoginResponse ApiSignIn(string email, string password)
        {
            SuccessfulLoginResponse output = new SuccessfulLoginResponse();
            var user = usersDAL.GetUser(email);
            var hashProvider = new HashProvider();

            if (user != null && hashProvider.VerifyPasswordMatch(user.Password, password, user.Salt))
            {
                string newAccessToken = GenerateAccessToken();
                loggedInUsers.Add(newAccessToken, user);
                output.AccessToken = newAccessToken;
                output.User = user;
            }
            else
            {
                output = null;
            }

            return output;
        }

        public bool LogOff()
        {
            return loggedInUsers.Remove(GetAccessTokenFromHeaders());
        }

        public bool ChangePassword(string existingPassword, string newPassword)
        {
            return false;
        }

        public bool Register(string displayName, string email, string password, string role)
        {
            return false;
        }

        public bool UserHasRole(string[] roles)
        {
            return false;
        }

        public bool IsAdmin()
        {
            return false;
        }

        public bool WebsiteRequestExists()
        {
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
            do
            {
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                randomBytes = new byte[sessionKeyLength];
                crypto.GetBytes(randomBytes);
            }
            while (DoesAccessTokenAlreadyExist(randomBytes.ToString()));

            return ConvertByteArrayToString(randomBytes);
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
    }
}
