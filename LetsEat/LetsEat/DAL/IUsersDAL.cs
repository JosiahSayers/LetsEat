using LetsEat.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        User GetUser(int id);
        User GetUser(int id, SqlConnection conn);

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

        bool DeleteInvite(User user);

        bool ChangeFamily(User user);

        List<User> SearchForUsersNotInFamily(string email);

        bool InviteUserToFamily(Invite invite);

        bool DoesEmailAlreadyExist(string email);
    }
}