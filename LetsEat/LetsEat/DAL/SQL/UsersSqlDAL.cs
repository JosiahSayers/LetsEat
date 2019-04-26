﻿using System;
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
        private const string sql_CreateUser = "INSERT INTO users (display_name, email, password, salt, role, family_id) VALUES (@displayName, @email, @password, @salt, @role, 0);";
        private const string sql_DeleteUser = "DELETE FROM users WHERE id = @id;";
        private const string sql_GetUser = "SELECT * FROM USERS WHERE email = @email;";
        private const string SQL_GetUserById = "SELECT * FROM users WHERE id = @id";
        private const string SQL_AddUserToFamily = "UPDATE users SET family_id = @family_id. family_role = @family_role WHERE id = @user_id";
        private const string SQL_UpdateUserRecipesToNewFamily = "UPDATE recipe SET family_id = @family_id WHERE user_id = @user_id";

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

        public User GetUser(int id, SqlConnection conn)
        {
            User user = null;
            try
            {
                SqlCommand cmd = new SqlCommand(SQL_GetUserById, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = MapRowToUser(reader);
                }
                reader.Close();
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

        public bool ChangeFamily(User user)
        {
            bool output;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AddUserToFamily, conn);
                    cmd.Parameters.AddWithValue("@family_id", user.FamilyId);
                    cmd.Parameters.AddWithValue("@family_role", user.FamilyRole);
                    cmd.Parameters.AddWithValue("@user_id", user.Id);

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(SQL_UpdateUserRecipesToNewFamily, conn);
                    cmd.Parameters.AddWithValue("@family_id", user.FamilyId);
                    cmd.Parameters.AddWithValue("@user_id", user.Id);

                    cmd.ExecuteNonQuery();
                }

                output = true;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        private User MapRowToUser(SqlDataReader reader)
        {
            User u = new User();

            u.Id = Convert.ToInt32(reader["id"]);
            u.DisplayName = Convert.ToString(reader["display_name"]);
            u.Email = Convert.ToString(reader["email"]);
            u.Password = Convert.ToString(reader["password"]);
            u.Salt = Convert.ToString(reader["salt"]);
            u.Role = Convert.ToString(reader["role"]);
            if (!reader.IsDBNull(reader.GetOrdinal("family_id")))
            {
                u.FamilyId = Convert.ToInt32(reader["family_id"]);
            }
            if (!reader.IsDBNull(reader.GetOrdinal("family_role")))
            {
                u.FamilyRole = Convert.ToString(reader["family_role"]);
            }

            return u;
        }
    }
}
