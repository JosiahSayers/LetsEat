using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using LetsEat.DAL;
using LetsEat.DAL.SQL;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;

namespace LetsEat.Models.Forms
{
    public class ParseURLForm
    {
        public string URL { get; set; }
        private readonly string[] supportedWebsites = { "allrecipes.com", "foodnetwork.com", "myrecipes.com/recipe"};

        public Recipe Parse()
        {
            Recipe output = new Recipe();
            output.Ingredients = new List<string>();
            output.Steps = new List<string>();
            output.ImageLocations = new List<string>();
            string titleNode = "";
            string descriptionNode = "";
            string imgNode = "";
            string stepsNode = "";
            string ingredientNode = "";
            string prepTimeNode = "";
            string cookTimeNode = "";
            string website = "";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(URL);

            HtmlNode node;

            if (URL.Contains("allrecipes.com"))
            {
                website = "allrecipes.com";
                output.Source = "All Recipes";
                titleNode = "//h1[@itemprop='name']";
                descriptionNode = "//div[@itemprop='description']";
                imgNode = "//img[@class='rec-photo']";
                stepsNode = "//li[@class='step']";
                ingredientNode = "//span[@itemprop='recipeIngredient']";
                prepTimeNode = "//time[@itemprop='prepTime']";
                cookTimeNode = "//time[@itemprop='cookTime']";

                node = doc.DocumentNode.SelectSingleNode(prepTimeNode);
                HtmlNodeCollection prepTime = node.FirstChild.ChildNodes;
                int min = 0;
                int hour = 0;
                if (prepTime.Count() > 2)
                {
                    hour = Convert.ToInt32(prepTime[0].InnerText);
                    min = Convert.ToInt32(prepTime[1].InnerText);
                }
                else
                {
                    min = Convert.ToInt32(prepTime[0].InnerText);
                }
                output.PrepMinutes = (hour * 60) + min;

                node = doc.DocumentNode.SelectSingleNode(cookTimeNode);
                HtmlNodeCollection cookTime = node.FirstChild.ChildNodes;
                min = 0;
                hour = 0;
                if (cookTime.Count() > 2)
                {
                    hour = Convert.ToInt32(cookTime[0].InnerText);
                    min = Convert.ToInt32(cookTime[2].InnerText);
                }
                else
                {
                    min = Convert.ToInt32(cookTime[0].InnerText);
                }
                output.CookMinutes = (hour * 60) + min;

                node = doc.DocumentNode.SelectSingleNode(titleNode);
                if (node != null)
                {
                    output.Name = node.InnerText;
                }

                node = doc.DocumentNode.SelectSingleNode(descriptionNode);
                if (node != null)
                {
                    output.Description = node.InnerText;
                }
                while (output.Description.Contains("&#34;"))
                {
                    output.Description = output.Description.Remove(output.Description.IndexOf("&#34;"), 5);
                }
                output.Description.Trim();
                if (output.Description[0] == ' ')
                {
                    output.Description.Remove(0, 1);
                }

                node = doc.DocumentNode.SelectSingleNode(imgNode);
                List<string> images = new List<string>();
                if (node != null)
                {
                    images.Add(node.GetAttributeValue("src", ""));
                }
                output.ImageLocations = images;

                output.Source = URL;

                output.DateAdded = DateTime.Now;

                HtmlNodeCollection stepNodes = doc.DocumentNode.SelectNodes(stepsNode);
                List<string> steps = new List<string>();
                foreach (HtmlNode step in stepNodes)
                {
                    steps.Add(step.InnerText);
                    if (String.IsNullOrWhiteSpace(steps[steps.Count - 1]))
                    {
                        steps.RemoveAt(steps.Count - 1);
                    }
                }
                output.Steps = steps;

                HtmlNodeCollection ingredientNodes = doc.DocumentNode.SelectNodes(ingredientNode);
                List<string> ingredients = new List<string>();
                foreach (HtmlNode ingredient in ingredientNodes)
                {
                    ingredients.Add(ingredient.InnerText);
                }
                output.Ingredients = ingredients;
            }
            else if (URL.Contains("foodnetwork.com"))
            {
                website = "foodnetwork.com";
                //titleNode = "//span[@class='o - AssetTitle__a - HeadlineText']";
                //descriptionNode = "//span[@class='originalText']";
                //imgNode = "//img[@class='m-MediaBlock__a-Image a-Image']";
                //stepsNode = "//div[@class='0-Method__m-Body']";
                //ingredientNode = "//div[@class='0-Ingredients__m-Body']";
                //prepTimeNode = "na";
                //cookTimeNode = "na";

                ScrapingBrowser browser = new ScrapingBrowser();

                //set UseDefaultCookiesParser as false if a website returns invalid cookies format
                //browser.UseDefaultCookiesParser = false;

                WebPage homePage = browser.NavigateToPage(new Uri(URL));

                HtmlNode[] nodes = homePage.Html.CssSelect("span.o-AssetTitle__a-HeadlineText").ToArray();
                if (nodes.Length > 0)
                {
                    output.Name = nodes[0].InnerText;
                }
                else output.Name = "Could not find name";

                nodes = homePage.Html.CssSelect("div.o-AssetDescription__a-Description").ToArray();
                if (nodes.Length > 0)
                {
                    output.Description = nodes[0].ChildNodes[0].InnerText;
                }
                else
                {
                    output.Description = "Could not find Description";
                }

                nodes = homePage.Html.CssSelect("img.m-MediaBlock__a-Image").ToArray();
                if (nodes.Length > 0)
                {
                    List<string> images = new List<string>();
                    images.Add(nodes[0].GetAttributeValue("src"));
                    output.ImageLocations = images;
                }

                nodes = homePage.Html.CssSelect("p.o-Ingredients__a-Ingredient").ToArray();
                List<string> ingredients = new List<string>();
                if (nodes.Length > 0)
                {
                    foreach (HtmlNode ing in nodes)
                    {
                        ingredients.Add(ing.InnerText);
                    }
                }
                else
                {
                    ingredients.Add("Error finding ingredients");
                }
                output.Ingredients = ingredients;

                nodes = homePage.Html.CssSelect("li.o-Method__m-Step").ToArray();
                List<string> steps = new List<string>();
                if (nodes.Length > 0)
                {
                    foreach (HtmlNode step in nodes)
                    {
                        steps.Add(step.InnerText);
                    }
                }
                else
                {
                    steps.Add("Error finding steps");
                }
                output.Steps = steps;

                nodes = homePage.Html.CssSelect("ul.o-RecipeInfo__m-Time").ToArray();
                string time = nodes[0].ChildNodes[3].ChildNodes[3].InnerText.ToLower();
                int minutes = 0;
                if (time.Contains("hr"))
                {
                    string hours = time.Substring(0, time.IndexOf("hr"));
                    hours.Trim();
                    minutes += Convert.ToInt32(hours);
                    minutes *= 60;
                    time = time.Substring(time.IndexOf("hr") + 3);
                    time = time.Trim();
                }
                if (time.Contains("min"))
                {
                    time = time.Remove(time.IndexOf("min"), 3);
                    time = time.Trim();
                }
                output.PrepMinutes = Convert.ToInt32(time) + minutes;

                minutes = 0;
                time = nodes[0].ChildNodes[1].ChildNodes[3].InnerText.ToLower();
                if (time.Contains("hr"))
                {
                    string hours = time.Substring(0, time.IndexOf("hr"));
                    time = time.Remove(0, time.IndexOf("hr") + 2);
                    time = time.Trim();
                    hours = hours.Trim();
                    minutes += Convert.ToInt32(hours);
                    minutes *= 60;
                }
                if (time.Contains("min"))
                {
                    time = time.Remove(time.IndexOf("min"), 3);
                    time = time.Trim();
                }
                output.CookMinutes = (Convert.ToInt32(time) + minutes) - output.PrepMinutes;
            }
            else if (URL.Contains("myrecipes.com/recipe"))
            {
                website = "myrecipes.com";

                ScrapingBrowser browser = new ScrapingBrowser();
                WebPage homePage = browser.NavigateToPage(new Uri(URL));

                node = homePage.Html.CssSelect("h1.headline").Single();
                output.Name = node.InnerText;

                node = homePage.Html.CssSelect("div.recipe-summary").Single();
                node = node.ChildNodes[1];
                output.Description = node.InnerText;

                node = homePage.Html.CssSelect("div.ingredients").Single();
                node = node.ChildNodes[1];
                for (int i = 1; i < node.ChildNodes.Count; i += 2)
                {
                    output.Ingredients.Add(node.ChildNodes[i].InnerText);
                }

                HtmlNode[] nodes = homePage.Html.CssSelect("div.step").ToArray();
                foreach (HtmlNode stepDiv in nodes)
                {
                    foreach (HtmlNode step in stepDiv.ChildNodes)
                    {
                        if (step.Name == "p")
                        {
                            output.Steps.Add(step.InnerText);
                        }
                    }
                }

                nodes = homePage.Html.CssSelect("div.recipe-meta-item-body").ToArray();
                string time = nodes[0].InnerText.ToLower();
                int minutes = 0;
                if (time.ToLower().Contains("hours"))
                {
                    string hours = time.Substring(0, time.IndexOf("hours"));
                    hours.Trim();
                    minutes += Convert.ToInt32(hours);
                    minutes *= 60;
                    time = time.Substring(time.IndexOf("hours") + 6);
                    time = time.Trim();
                }
                if (time.ToLower().Contains("hour"))
                {
                    string hours = time.Substring(0, time.IndexOf("hour"));
                    hours.Trim();
                    minutes += Convert.ToInt32(hours);
                    minutes *= 60;
                    time = time.Substring(time.IndexOf("hour") + 5);
                    time = time.Trim();
                }
                if (time.ToLower().Contains("min"))
                {
                    time = time.Remove(time.IndexOf("min"), 4);
                    time = time.Trim();
                }
                output.PrepMinutes = Convert.ToInt32(time) + minutes;

                minutes = 0;
                time = nodes[1].InnerText.ToLower();
                if (time.ToLower().Contains("hours"))
                {
                    string hours = time.Substring(0, time.IndexOf("hours"));
                    hours.Trim();
                    minutes += Convert.ToInt32(hours);
                    minutes *= 60;
                    time = time.Substring(time.IndexOf("hours") + 6);
                    time = time.Trim();
                }
                if (time.ToLower().Contains("hour"))
                {
                    string hours = time.Substring(0, time.IndexOf("hour"));
                    time = time.Remove(0, time.IndexOf("hour") + 5);
                    time = time.Trim();
                    hours = hours.Trim();
                    minutes += Convert.ToInt32(hours);
                    minutes *= 60;
                }
                if (time.ToLower().Contains("min"))
                {
                    time = time.Remove(time.IndexOf("min"), 4);
                    time = time.Trim();
                }
                output.CookMinutes = (Convert.ToInt32(time) + minutes) - output.PrepMinutes;
            }
            else if (URL.Contains("tasteofhome.com"))
            {
                output.Source = "Taste of Home";
                throw new NotImplementedException();
            }
            else if (URL.Contains("delish.com"))
            {
                output.Source = "Delish";
                throw new NotImplementedException();

            }
            else if (URL.Contains("skinnytaste.com"))
            {
                output.Source = "Skinny Taste";
                throw new NotImplementedException();

            }
            else if (URL.Contains("thekitchn.com"))
            {
                output.Source = "The Kitchn";
                throw new NotImplementedException();

            }

            for(int i=0; i<output.Steps.Count; i++)
            {
                output.Steps[i] = output.Steps[i].Trim();
            }

            for (int i = 0; i < output.Ingredients.Count; i++)
            {
                output.Ingredients[i] = output.Ingredients[i].Trim();
            }

            output.DateAdded = DateTime.Now;
            output.Source = URL;

            return output;
        }

        public bool IsSupportedWebsite()
        {
            foreach(string site in supportedWebsites)
            {
                if (URL.Contains(site))
                {
                    return true;
                }
            }
            return false;
        }

        public WebsiteRequest GenerateWebsiteRequest()
        {
            Regex regex = new Regex(@"(http(s)?:\/\/)|(\/.*){1}", RegexOptions.IgnoreCase | RegexOptions.ECMAScript);

            WebsiteRequest wr = new WebsiteRequest()
            {
                BaseURL = regex.Replace(URL, "").ToString(),
                FullURL = URL
            };

            return wr;
        }
    }
}
