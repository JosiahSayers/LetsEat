using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models.Forms
{
    public class ImageUpload
    {
        public string RecipeId { get; set; }
        public Microsoft.AspNetCore.Http.IFormFile File { get; set; }
    }
}
