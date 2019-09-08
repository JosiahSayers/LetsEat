namespace LetsEat.Models.RecipeBook
{
    public class RecipeBookErrorMessages : BaseError
    {
        public Error MyRecipes
        {
            get
            {
                return this.ErrorResult("Error Retrieving recipes for user");
            }
        }

        public Error FamilyRecipes
        {
            get
            {
                return this.ErrorResult("Error Retrieving recipes for family");
            }
        }

        public Error NotInFamily
        {
            get
            {
                return this.ErrorResult("User is not in a family");
            }
        }

        public Error ParseUrl
        {
            get
            {
                return this.ErrorResult("Error Parsing URL");
            }
        }
    }
}
