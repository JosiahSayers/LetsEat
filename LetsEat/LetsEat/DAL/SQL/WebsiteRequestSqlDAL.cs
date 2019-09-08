using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LetsEat.Models;

namespace LetsEat.DAL.SQL
{
    public class WebsiteRequestSqlDAL : IWebsiteRequestDAL
    {
        private string connectionString;
        private readonly IUsersDAL userDAL;

        private readonly string SQL_Get_New_Websites = "SELECT * FROM website_requests;";
        private readonly string SQL_Add_New_Website_Request = "INSERT INTO website_requests (base_url, full_url, user_id) VALUES (@base_url, @full_url, @user_id);";
        private readonly string SQL_Get_Request_By_ID = "SELECT * FROM website_requests WHERE id = @id;";
        private readonly string SQL_Delete_Request = "DELETE FROM website_requests WHERE id = @id;";

        public WebsiteRequestSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
            userDAL = new UserSqlDAL(connectionString);
        }

        public List<WebsiteRequest> GetNewWebsiteRequests()
        {
            List<WebsiteRequest> output = new List<WebsiteRequest>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_Get_New_Websites, conn);
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        WebsiteRequest wr = new WebsiteRequest();
                        wr.Id = Convert.ToInt32(reader["id"]);
                        wr.BaseURL = Convert.ToString(reader["base_url"]);
                        wr.FullURL = Convert.ToString(reader["full_url"]);
                        wr.User = new User()
                        {
                            Id = Convert.ToInt32(reader["user_id"])
                        };

                        output.Add(wr);
                    }
                    reader.Close();

                    foreach (WebsiteRequest wr in output)
                    {
                        wr.User = userDAL.GetUser(wr.User.Id, conn);
                    }
                }
            }
            catch
            {
                output = null;
            }

            return output;
        }

        public bool AddNewWebsiteRequest(WebsiteRequest newRequest)
        {
            bool output = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_Add_New_Website_Request, conn);
                    cmd.Parameters.AddWithValue("@base_url", newRequest.BaseURL);
                    cmd.Parameters.AddWithValue("@full_url", newRequest.FullURL);
                    cmd.Parameters.AddWithValue("@user_id", newRequest.User.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool? WebsiteRequestExists()
        {
            bool? output;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_Get_New_Websites, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output = true;
                    }
                    else
                    {
                        output = false;
                    }
                }
            }
            catch
            {
                output = null;
            }

            return output;
        }

        public WebsiteRequest Get(int id)
        {
            WebsiteRequest output = new WebsiteRequest();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_Get_Request_By_ID, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output.Id = Convert.ToInt32(reader["id"]);
                        output.BaseURL = Convert.ToString(reader["base_url"]);
                        output.FullURL = Convert.ToString(reader["full_url"]);
                        output.User = new User()
                        {
                            Id = Convert.ToInt32(reader["user_id"])
                        };
                    }

                    reader.Close();

                    output.User = userDAL.GetUser(output.User.Id, conn);
                }
            }
            catch
            {
                output = null;
            }

            return output;
        }

        public bool Delete(int id)
        {
            bool output;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_Delete_Request, conn);
                    cmd.Parameters.AddWithValue("@id", id);

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
    }
}
