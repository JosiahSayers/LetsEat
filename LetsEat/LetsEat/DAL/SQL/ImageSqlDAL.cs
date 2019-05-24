using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LetsEat.Models;

namespace LetsEat.DAL.SQL
{
    public class ImageSqlDAL : IImageDAL
    {
        private string connectionString;

        private string SQL_GetImageLocationsForRecipe = "SELECT filename FROM images WHERE recipe_id = @recipeID;";
        private string SQL_AssignImageLocationToRecipe = "INSERT INTO images (recipe_id, filename) VALUES (@recipeID, @filename);";
        private string SQL_DeleteILForRecipe = "DELETE FROM images WHERE recipe_id = @recipeId;";

        public ImageSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<string> GetImageLocationsForRecipe(int recipeID)
        {
            List<string> output = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetImageLocationsForRecipe, conn);
                    cmd.Parameters.AddWithValue("@recipeID", recipeID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(Convert.ToString(reader["filename"]));
                    }
                }
            }
            catch
            {
                output.Clear();
                output.Add("error");
            }

            return output;
        }

        public List<string> GetImageLocationsForRecipe(int recipeID, SqlConnection conn)
        {
            List<string> output = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand(SQL_GetImageLocationsForRecipe, conn);
                cmd.Parameters.AddWithValue("@recipeID", recipeID);
                SqlDataReader imgReader = cmd.ExecuteReader();

                while (imgReader.Read())
                {
                    output.Add(Convert.ToString(imgReader["filename"]));
                }
                imgReader.Close();
            }
            catch
            {
                output.Clear();
                output.Add("error");
            }

            return output;
        }

        public bool AssignImageLocationToRecipe(string imgLoc, Recipe recipe)
        {
            bool output;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AssignImageLocationToRecipe, conn);
                    cmd.Parameters.AddWithValue("@recipeID", recipe.ID);
                    cmd.Parameters.AddWithValue("@filename", imgLoc);

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

        public void UpdateImageLocationsForRecipe(int recipeId, List<string> imageLocations, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(SQL_DeleteILForRecipe, conn);
            cmd.Parameters.AddWithValue("@recipeId", recipeId);
            cmd.ExecuteNonQuery();

            foreach (string il in imageLocations)
            {
                cmd = new SqlCommand(SQL_AssignImageLocationToRecipe, conn);
                cmd.Parameters.AddWithValue("@recipeID", recipeId);
                cmd.Parameters.AddWithValue("@filename", il);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
