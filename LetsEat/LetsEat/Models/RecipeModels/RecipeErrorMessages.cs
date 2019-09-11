namespace LetsEat.Models.RecipeModels
{
    public class RecipeErrorMessages : BaseError
    {
        public Error RecipeError
        {
            get
            {
                return this.ErrorResult("Error on recipe api endpoint");
            }
        }

        public Error NotAuthorized
        {
            get
            {
                return this.ErrorResult("User not authorized to access this recipe");
            }
        }

        public Error Deleted
        {
            get
            {
                return this.ErrorResult("Recipe successfully deleted.");
            }
        }
    }
}