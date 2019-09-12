using LetsEat.Models;
using LetsEat.Models.RecipeBook;
using LetsEat.Providers.Auth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LetsEat.DAL.SQL
{
    public class RecipeSqlDAL : IRecipeDAL
    {
        private string connectionString;

        private string SQL_GetMyRecipes = "SELECT * FROM recipe JOIN users ON recipe.user_id = users.id WHERE recipe.user_id = @user_id";
        private string SQL_GetRecipeByID = "SELECT * FROM recipe JOIN users on recipe.user_id = users.id WHERE recipe.id = @id";
        private string SQL_SearchForRecipe = "SELECT DISTINCT recipe.ID, recipe.name FROM recipe JOIN ingredient ON recipe.id = ingredient.recipe_id WHERE recipe.name LIKE (@searchQuery) OR recipe.description LIKE (@searchQuery) OR ingredient.ingredient LIKE (@searchQuery);";
        private string SQL_CreateRecipe = "INSERT INTO recipe (name, description, prep_minutes, cook_minutes, source, date_added, user_id, family_id) VALUES (@name, @description, @prepMinutes, @cookMinutes, @source, @dateAdded, @userWhoAdded, @family_id); SELECT CAST(SCOPE_IDENTITY() as int);";
        private string SQL_CreateRecipeNoFamily = "INSERT INTO recipe (name, description, prep_minutes, cook_minutes, source, date_added, user_id) VALUES (@name, @description, @prepMinutes, @cookMinutes, @source, @dateAdded, @userWhoAdded); SELECT CAST(SCOPE_IDENTITY() as int);";
        private string SQL_GetFamilyRecipes = "SELECT * FROM recipe JOIN users ON recipe.user_id = users.id WHERE recipe.family_id = @family_id;";
        private string SQL_DeleteRecipe = "DELETE FROM steps WHERE recipe_id = @id; DELETE FROM images WHERE recipe_id = @id; DELETE FROM ingredient WHERE recipe_id = @id; DELETE FROM recipe WHERE id = @id;";
        private string SQL_UpdateRecipe = "UPDATE recipe SET name = @name, description = @description, prep_minutes = @prep_minutes, cook_minutes = @cook_minutes WHERE id = @id;";

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

                    if (reader.Read())
                    {
                        output = MapRowToRecipe(reader);
                    }

                    reader.Close();

                    output.Steps = stepDAL.GetStepsForRecipe(id, conn);
                    output.Ingredients = ingredientDAL.GetIngredientsForRecipe(id, conn);
                    output.ImageLocations = imgDAL.GetImageLocationsForRecipe(id, conn);
                }

            }
            catch
            {
                output = null;
            }

            return output;
        }

        public List<Recipe> GetMyRecipes(int userId)
        {
            List<Recipe> output = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetMyRecipes, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(MapRowToRecipe(reader));
                    }
                    reader.Close();

                    output = MapSupplementals(output, conn);
                }
            }
            catch
            {
                output.Clear();
            }

            return output;
        }

        public List<Recipe> GetFamilyRecipes(int familyId)
        {
            List<Recipe> output = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetFamilyRecipes, conn);
                    cmd.Parameters.AddWithValue("@family_id", familyId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(MapRowToRecipe(reader));
                    }

                    reader.Close();

                    output = MapSupplementals(output, conn);
                }
            }
            catch
            {
                output = null;
            }

            return output;
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd;
                    if (recipe.UserWhoAdded.FamilyId > 0)
                    {
                        cmd = new SqlCommand(SQL_CreateRecipe, conn);
                        cmd.Parameters.AddWithValue("@family_id", recipe.UserWhoAdded.FamilyId);
                    }
                    else
                    {
                        cmd = new SqlCommand(SQL_CreateRecipeNoFamily, conn);
                    }

                    cmd.Parameters.AddWithValue("@name", recipe.Name);
                    cmd.Parameters.AddWithValue("@description", recipe.Description);
                    cmd.Parameters.AddWithValue("@prepMinutes", recipe.PrepMinutes);
                    cmd.Parameters.AddWithValue("@cookMinutes", recipe.CookMinutes);
                    cmd.Parameters.AddWithValue("@source", recipe.Source);
                    cmd.Parameters.AddWithValue("@dateAdded", recipe.DateAdded);
                    cmd.Parameters.AddWithValue("@userWhoAdded", recipe.UserWhoAdded.Id);

                    conn.Open();

                    recipe.ID = (int)cmd.ExecuteScalar();
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
                recipe = null;
            }

            return recipe;
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

        public SearchResults NewSearch(string searchQuery)
        {
            SearchResults output = new SearchResults();
            searchQuery = $"%{searchQuery}%";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SearchForRecipe, conn);
                    cmd.Parameters.AddWithValue("@searchQuery", searchQuery);

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        output.Recipes.Add(new RecipeSearchResults(id, name));
                    }
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

                    SqlCommand cmd = new SqlCommand(SQL_DeleteRecipe, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    output = true;
                }
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool Update(Recipe recipe)
        {
            bool output = true;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_UpdateRecipe, conn);
                    cmd.Parameters.AddWithValue("@id", recipe.ID);
                    cmd.Parameters.AddWithValue("@name", recipe.Name);
                    cmd.Parameters.AddWithValue("@description", recipe.Description);
                    cmd.Parameters.AddWithValue("@prep_minutes", recipe.PrepMinutes);
                    cmd.Parameters.AddWithValue("@cook_minutes", recipe.CookMinutes);

                    cmd.ExecuteNonQuery();

                    //imgDAL.UpdateImageLocationsForRecipe(recipe.ID, recipe.ImageLocations, conn);
                    ingredientDAL.UpdateIngredients(recipe.ID, recipe.Ingredients, conn);
                    stepDAL.UpdateStepsForRecipe(recipe.ID, recipe.Steps, conn);
                }
            }
            catch
            {
                output = false;
            }
            return output;
        }

        private Recipe MapRowToRecipe(SqlDataReader reader, bool includeEmail = false)
        {
            Recipe r = new Recipe();
            r.ID = Convert.ToInt32(reader["id"]);
            r.Name = Convert.ToString(reader["name"]);
            r.PrepMinutes = Convert.ToInt32(reader["prep_minutes"]);
            r.CookMinutes = Convert.ToInt32(reader["cook_minutes"]);
            r.Description = Convert.ToString(reader["description"]);
            r.Source = Convert.ToString(reader["source"]);
            r.DateAdded = Convert.ToDateTime(reader["date_added"]);
            if (!reader.IsDBNull(reader.GetOrdinal("family_id")))
            {
                r.FamilyID = Convert.ToInt32(reader["family_id"]);
            }

            r.UserWhoAdded = new User()
            {
                Id = Convert.ToInt32(reader["user_id"]),
                DisplayName = Convert.ToString(reader["display_name"]),
            };

            if (includeEmail)
            {
                r.UserWhoAdded.Email = Convert.ToString(reader["email"]);

            }

            return r;
        }

        private List<Recipe> MapSupplementals(List<Recipe> recipes, SqlConnection conn)
        {
            foreach (Recipe r in recipes)
            {
                r.Steps = stepDAL.GetStepsForRecipe(r.ID, conn);
            }

            foreach (Recipe r in recipes)
            {
                r.Ingredients = ingredientDAL.GetIngredientsForRecipe(r.ID, conn);
            }

            foreach (Recipe r in recipes)
            {
                r.ImageLocations = imgDAL.GetImageLocationsForRecipe(r.ID, conn);
            }

            return recipes;
        }
    }
}


