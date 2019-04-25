using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LetsEat.Models.Forms
{
    public class AddRecipeForm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string UserWhoAdded { get; set; }
        [DisplayName("Prep Time (in minutes)")]
        public int PrepMinutes { get; set; }
        [DisplayName("Cook Time (in minutes)")]
        public int CookMinutes { get; set; }

        [DisplayName("Ingredients ('|' Seperated)")]
        public string Ingredients { get; set; }
        [DisplayName("Image URLs ('|' Seperated)")]
        public string ImageLocations { get; set; }
        [DisplayName("Steps ('|' Seperated)")]
        public string Steps { get; set; }

        public List<string> IngredientsList { get; set; }
        public List<string> ImagesList { get; set; }
        public List<string> StepsList { get; set; }


        public List<string> ParseIngredients()
        {
            List<string> output = new List<string>();

            if (!String.IsNullOrWhiteSpace(Ingredients))
            {
                string[] temp = Ingredients.Split('|');
                output.AddRange(temp);
            }

            return output;
        }

        public List<string> ParseImageLocations()
        {
            List<String> output = new List<string>();
            if (!String.IsNullOrWhiteSpace(ImageLocations))
            {
                output.AddRange(ImageLocations.Split('|'));
            }
            return output;
        }

        public List<string> ParseSteps()
        {
            List<string> output = new List<string>();
            if (!String.IsNullOrWhiteSpace(Steps))
            {
                output.AddRange(Steps.Split('|'));
            }
            return output;
        }
    }
}
