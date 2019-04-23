﻿using LetsEat.Models;

namespace LetsEat.DAL
{
    public interface IUsersDAL
    {
        /// <summary>
        /// Retrieves a user from the system by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUser(string email);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        ///  /// <returns></returns>
        bool CreateUser(User user);

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(User user);
    }
}