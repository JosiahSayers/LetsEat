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

        public WebsiteRequestSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
            userDAL = new UserSqlDAL(connectionString);
        }

        public List<WebsiteRequest> GetNewWebsiteRequests()
        {
            List<WebsiteRequest> output = new List<WebsiteRequest>();

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

                    output.Add(wr);
                }
                reader.Close();
                
                foreach(WebsiteRequest wr in output)
                {
                    userDAL.GetUser(wr.Id, conn);
                }
            }

            return output;
        }

        public void AddNewWebsiteRequest(WebsiteRequest newRequest)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL_Add_New_Website_Request, conn);
                cmd.Parameters.AddWithValue("@base_url", newRequest.BaseURL);
                cmd.Parameters.AddWithValue("@full_url", newRequest.FullURL);
                cmd.Parameters.AddWithValue("@user_id", newRequest.user.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
