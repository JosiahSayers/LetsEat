using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LetsEat.Models;

namespace LetsEat.DAL.SQL
{
    public class StepSqlDAL : IStepDAL
    {
        private string connectionString;

        private string SQL_GetStepsForRecipe = "SELECT step_number, step_text FROM steps WHERE recipe_id = @recipeID ORDER BY step_number, step_text;";
        private string SQL_AddStepToRecipe = "INSERT INTO steps (recipe_id, step_number, step_text) VALUES (@recipeID, @stepNumber, @stepText); ";
        private string SQL_DeleteStepsForRecipe = "DELETE FROM steps WHERE recipe_id = @recipeID;";

        public StepSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<string> GetStepsForRecipe(int recipeID)
        {
            List<string> output = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetStepsForRecipe, conn);
                    cmd.Parameters.AddWithValue("@recipeID", recipeID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(Convert.ToString(reader["step_text"]));
                    }
                }
            }
            catch
            {
                output[0] = "error";
            }

            return output;
        }

        public List<string> GetStepsForRecipe(int recipeID, SqlConnection conn)
        {
            List<string> output = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand(SQL_GetStepsForRecipe, conn);
                cmd.Parameters.AddWithValue("@recipeID", recipeID);
                SqlDataReader stepReader = cmd.ExecuteReader();

                while (stepReader.Read())
                {
                    output.Add(Convert.ToString(stepReader["step_text"]));
                }
                stepReader.Close();
            }
            catch
            {
                output[0] = "error";
            }

            return output;
        }

        public bool AddStepsForRecipe(int stepNumber, string stepText, Recipe recipe)
        {
            bool output;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AddStepToRecipe, conn);
                    cmd.Parameters.AddWithValue("@recipeID", recipe.ID);
                    cmd.Parameters.AddWithValue("@stepNumber", stepNumber);
                    cmd.Parameters.AddWithValue("@stepText", stepText);

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

        public void UpdateStepsForRecipe(int recipeId, List<string> steps, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(SQL_DeleteStepsForRecipe, conn);
            cmd.Parameters.AddWithValue("@recipeID", recipeId);

            cmd.ExecuteNonQuery();

            for (int i = 0; i < steps.Count; i++)
            {
                cmd = new SqlCommand(SQL_AddStepToRecipe, conn);
                cmd.Parameters.AddWithValue("@recipeID", recipeId);
                cmd.Parameters.AddWithValue("@stepNumber", (i + 1));
                cmd.Parameters.AddWithValue("@stepText", steps[i]);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
