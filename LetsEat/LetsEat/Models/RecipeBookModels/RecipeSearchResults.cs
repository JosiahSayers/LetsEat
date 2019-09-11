using System;
namespace LetsEat.Models.RecipeBookModels
{
    public class RecipeSearchResults
    {
        public int Id { get; }
        public string Name { get; }

        public RecipeSearchResults(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
