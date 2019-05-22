using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;
using LetsEat.Models.Forms;
using LetsEat.DAL;
using LetsEat.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsEat.Controllers.API
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment environment;
        private readonly IImageDAL imageDAL;

        public ImageController(IHostingEnvironment environment, IImageDAL imageDAL)
        {
            this.environment = environment;
            this.imageDAL = imageDAL;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(ImageUpload upload)
        {
            string location = "";
            Random rand = new Random();

            if (!Directory.Exists(environment.WebRootPath + "\\uploads\\"))
            {
                Directory.CreateDirectory(environment.WebRootPath + "\\uploads\\");
            }

            using (FileStream fs = System.IO.File.Create(environment.WebRootPath + "\\uploads\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + rand.Next(256) + upload.File.FileName))
            {
                upload.File.CopyTo(fs);
                fs.Flush();
                location = "/uploads/" + upload.File.FileName;
            }

            imageDAL.AssignImageLocationToRecipe(location, new Recipe() { ID = Convert.ToInt32(upload.RecipeId) });
        }
    }
}
