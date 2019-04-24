using LetsEat.Models;
using LetsEat.Providers.Auth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LetsEat.DAL.SQL
{
    public class RecipeSqlDAL:IRecipeDAL
    {
        private string connectionString;

        private string SQL_GetAllRecipes = "SELECT * FROM recipe JOIN users ON recipe.user_who_added = users.id";
        private string SQL_GetRecipeByID = "SELECT * FROM recipe JOIN users on recipe.user_who_added = users.id WHERE id = @id";
        private string SQL_SearchForRecipe = "SELECT DISTINCT recipe.ID FROM recipe JOIN ingredient ON recipe.id = ingredient.recipe_id WHERE recipe.name LIKE (@searchQuery) OR recipe.description LIKE (@searchQuery) OR ingredient.ingredient LIKE (@searchQuery);";
        private string SQL_CreateRecipe = "INSERT INTO recipe (name, description, prep_minutes, cook_minutes, source, date_added, user_who_added) VALUES (@name, @description, @prepMinutes, @cookMinutes, @source, @dateAdded, @userWhoAdded); SELECT CAST(SCOPE_IDENTITY() as int);";

        private readonly IIngredientDAL ingredientDAL;
        private readonly IImageDAL imgDAL;
        private readonly IStepDAL stepDAL;

        public RecipeSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
            ingredientDAL = new IngredientSqlDAL(connectionString);
            imgDAL = new ImageSqlDAL(connectionString);
            stepDAL = new StepSqlDAL(connectionString);
        }

        public Recipe GetRecipeByID(int id)
        {
            Recipe output = new Recipe();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetRecipeByID, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int recipeID = Convert.ToInt32(reader["id"]);
                        output.ID = Convert.ToInt32(recipeID);
                        output.Name = Convert.ToString(reader["name"]);
                        output.PrepMinutes = Convert.ToInt32(reader["prep_minutes"]);
                        output.CookMinutes = Convert.ToInt32(reader["cook_minutes"]);
                        output.Description = Convert.ToString(reader["description"]);
                        output.Source = Convert.ToString(reader["source"]);
                        output.DateAdded = Convert.ToDateTime(reader["date_added"]);

                        output.UserWhoAdded = new User(){
                            DisplayName = Convert.ToString(reader["display_name"])
                        };
                    }
                }

                output.Ingredients = ingredientDAL.GetIngredientsForRecipe(id);
                output.ImageLocations = imgDAL.GetImageLocationsForRecipe(id);
                output.Steps = stepDAL.GetStepsForRecipe(id);
            }
            catch
            {
                output = null;
            }

            return output;
        }

        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> output = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllRecipes, conn);

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int recipeID = Convert.ToInt32(reader["id"]);
                        Recipe r = new Recipe();
                        r.ID = Convert.ToInt32(recipeID);
                        r.Name = Convert.ToString(reader["name"]);
                        r.PrepMinutes = Convert.ToInt32(reader["prep_minutes"]);
                        r.CookMinutes = Convert.ToInt32(reader["cook_minutes"]);
                        r.Description = Convert.ToString(reader["description"]);
                        r.Source = Convert.ToString(reader["source"]);
                        r.DateAdded = Convert.ToDateTime(reader["date_added"]);

                        r.UserWhoAdded = new User() {
                            DisplayName = Convert.ToString(reader["display_name"])
                        };

                        r.Ingredients = ingredientDAL.GetIngredientsForRecipe(recipeID);
                        r.ImageLocations = imgDAL.GetImageLocationsForRecipe(recipeID);
                        r.Steps = stepDAL.GetStepsForRecipe(recipeID);

                        output.Add(r);
                    }
                }
            }
            catch
            {
                output.Clear();
            }

            return output;
        }

        public int AddRecipe(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(SQL_CreateRecipe, conn);
                    cmd.Parameters.AddWithValue("@name", recipe.Name);
                    cmd.Parameters.AddWithValue("@description", recipe.Description);
                    cmd.Parameters.AddWithValue("@prepMinutes", recipe.PrepMinutes);
                    cmd.Parameters.AddWithValue("@cookMinutes", recipe.CookMinutes);
                    cmd.Parameters.AddWithValue("@source", recipe.Source);
                    cmd.Parameters.AddWithValue("@dateAdded", recipe.DateAdded);
                    cmd.Parameters.AddWithValue("@userWhoAdded", recipe.UserWhoAdded.Id);


                    conn.Open();

                    int recipeID = (int)cmd.ExecuteScalar();
                    recipe.ID = recipeID;
                }

                foreach (string i in recipe.Ingredients)
                {
                    int ingredientID = ingredientDAL.AddNewIngredient(i, recipe);
                    if (ingredientID == -1)
                    {
                        //something went wrong
                    }
                }

                foreach (string img in recipe.ImageLocations)
                {
                    imgDAL.AssignImageLocationToRecipe(img, recipe);
                }

                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    stepDAL.AddStepsForRecipe(i + 1, recipe.Steps[i], recipe);
                }

            }
            catch
            {
                recipe.ID = -1;
            }

            return recipe.ID;
        }

        public List<Recipe> SearchForRecipe(string searchQuery)
        {
            List<Recipe> output = new List<Recipe>();
            searchQuery = $"%{searchQuery}%";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL_SearchForRecipe, conn);
                cmd.Parameters.AddWithValue("@searchQuery", searchQuery);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    int recipeID = Convert.ToInt32(reader["id"]);
                    Recipe r = GetRecipeByID(recipeID);
                    output.Add(r);
                }
            }
            return output;
        }
    }
}


