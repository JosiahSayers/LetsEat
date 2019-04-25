using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PrepMinutes { get; set; }
        public int CookMinutes { get; set; }
        public string Source { get; set; }
        public DateTime DateAdded { get; set; }
        public User UserWhoAdded { get; set; }
        public int FamilyID { get; set; }

        public List<string> Ingredients { get; set; }
        public List<string> ImageLocations { get; set; }
        public List<string> Steps { get; set; }

        public string PrepTime
        {
            get
            {
                int minutes = PrepMinutes;
                int hours = 0;
                while (minutes >= 60)
                {
                    hours++;
                    minutes -= 60;
                }

                string hourString = hours > 1 ? $"{hours} hours" : hours == 0 ? "" : $"{hours} hour";
                string minuteString = minutes > 1 ? $"{minutes} minutes" : minutes == 0 ? "" : $"{minutes} minute";

                return $"{hourString} {minuteString}";
            }
        }

        public string CookTime
        {
            get
            {
                int minutes = CookMinutes;
                int hours = 0;
                while (minutes >= 60)
                {
                    hours++;
                    minutes -= 60;
                }

                string hourString = hours > 1 ? $"{hours} hours" : hours == 0 ? "" : $"{hours} hour";
                string minuteString = minutes > 1 ? $"{minutes} minutes" : minutes == 0 ? "" : $"{minutes} minute";

                return $"{hourString} {minuteString}";
            }
        }

        public int TotalTimeMinutes
        {
            get
            {
                return PrepMinutes + CookMinutes;
            }
        }

        public string TotalTime
        {
            get
            {
                int minutes = TotalTimeMinutes;
                int hours = 0;
                while (minutes >= 60)
                {
                    hours++;
                    minutes -= 60;
                }

                string hourString = hours > 1 ? $"{hours} hours" : hours == 0 ? "" : $"{hours} hour";
                string minuteString = minutes > 1 ? $"{minutes} minutes" : minutes == 0 ? "" : $"{minutes} minute";

                return $"{hourString} {minuteString}";
            }
        }
    }
}
