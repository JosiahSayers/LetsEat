using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.Models;

namespace LetsEat.DAL.SQL
{
    public class UserSqlDAL : IUsersDAL
    {
        private readonly string connectionString;
        private const string sql_CreateUser = "INSERT INTO users (display_name, email, password, salt, role) VALUES (@displayName, @email, @password, @salt, @role);";
        private const string sql_DeleteUser = "DELETE FROM users WHERE id = @id;";
        private const string sql_GetUser = "SELECT * FROM USERS WHERE email = @email;";

        public UserSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="user"></param>
        public bool CreateUser(User user)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql_CreateUser, conn);
                    cmd.Parameters.AddWithValue("@displayName", user.DisplayName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);

                    result = (cmd.ExecuteNonQuery() > 0) ? true : false;

                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Deletes the user from the database.
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql_DeleteUser, conn);
                    cmd.Parameters.AddWithValue("@id", user.Id);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch
            {
                //todo: add error handling
            }
        }

        /// <summary>
        /// Gets the user from the database.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUser(string email)
        {
            User user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql_GetUser, conn);
                    cmd.Parameters.AddWithValue("@email", email);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }


            }
            catch
            {
                user = null;
            }

            return user;
        }

        /// <summary>
        /// Updates the user in the database.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users SET display_name = @displayName, password = @password, salt = @salt, role = @role WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.Parameters.AddWithValue("@displayName", user.DisplayName);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch
            {
                //todo: add some error handling
            }
        }

        private User MapRowToUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = Convert.ToInt32(reader["id"]),
                DisplayName = Convert.ToString(reader["display_name"]),
                Email = Convert.ToString(reader["email"]),
                Password = Convert.ToString(reader["password"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["role"])
            };
        }
    }
}
