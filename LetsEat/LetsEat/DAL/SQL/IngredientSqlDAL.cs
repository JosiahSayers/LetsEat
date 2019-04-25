using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LetsEat.Models;

namespace LetsEat.DAL.SQL
{
    public class IngredientSqlDAL : IIngredientDAL
    {
        private string SQL_GetIngredientsForRecipe = "SELECT * FROM ingredient WHERE recipe_id = @recipeID;";
        private string SQL_GetIngredientID = "SELECT * FROM ingredient WHERE name = @name;";
        private string SQL_AddNewIngredient = "INSERT INTO ingredient (ingredient, recipe_id) VALUES (@ingredient, @recipeID); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        private string connectionString;

        public IngredientSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<string> GetIngredientsForRecipe(Recipe recipe)
        {
            List<string> output = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetIngredientsForRecipe, conn);
                    cmd.Parameters.AddWithValue("@recipeID", recipe.ID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string i = Convert.ToString(reader["ingredient"]);
                        output.Add(i);
                    }
                }
            }
            catch
            {
                output.Clear();
            }

            return output;
        }

        public List<string> GetIngredientsForRecipe(Recipe recipe, SqlConnection conn)
        {
            List<string> output = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand(SQL_GetIngredientsForRecipe, conn);
                cmd.Parameters.AddWithValue("@recipeID", recipe.ID);
                SqlDataReader ingReader = cmd.ExecuteReader();

                while (ingReader.Read())
                {
                    string i = Convert.ToString(ingReader["ingredient"]);
                    output.Add(i);
                }
                ingReader.Close();
            }
            catch
            {
                output.Clear();
            }

            return output;
        }

        public List<string> GetIngredientsForRecipe(int recipeID)
        {
            List<string> output = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetIngredientsForRecipe, conn);
                    cmd.Parameters.AddWithValue("@recipeID", recipeID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string i = Convert.ToString(reader["ingredient"]);
                        output.Add(i);
                    }
                }
            }
            catch
            {
                output.Clear();
            }

            return output;
        }

        public List<string> GetIngredientsForRecipe(int recipeID, SqlConnection conn)
        {
            List<string> output = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand(SQL_GetIngredientsForRecipe, conn);
                cmd.Parameters.AddWithValue("@recipeID", recipeID);
                SqlDataReader ingReader = cmd.ExecuteReader();

                while (ingReader.Read())
                {
                    string i = Convert.ToString(ingReader["ingredient"]);
                    output.Add(i);
                }
                ingReader.Close();
            }
            catch
            {
                output.Clear();
            }

            return output;
        }

        public int AddNewIngredient(string ingredient, Recipe recipe)
        {
            int output;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AddNewIngredient, conn);
                    cmd.Parameters.AddWithValue("@ingredient", ingredient);
                    cmd.Parameters.AddWithValue("@recipeID", recipe.ID);

                    output = (int)cmd.ExecuteScalar();
                }
            }
            catch
            {
                output = -1;
            }

            return output;
        }

        public int AddNewIngredient(string ingredient, int recipeID)
        {
            int output;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AddNewIngredient, conn);
                    cmd.Parameters.AddWithValue("@ingredient", ingredient);
                    cmd.Parameters.AddWithValue("@recipeID", recipeID);

                    output = (int)cmd.ExecuteScalar();
                }
            }
            catch
            {
                output = -1;
            }

            return output;
        }
    }
}
