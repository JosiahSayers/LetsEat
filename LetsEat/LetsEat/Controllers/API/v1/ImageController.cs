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
using LetsEat.Models.RecipeModels;
using LetsEat.Providers.Storage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsEat.Controllers.API.v1
{
    [Route("api/v1/[controller]")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment environment;
        private readonly IImageDAL imageDAL;
        private readonly GoogleCloudStorage cloudStorage;

        public ImageController(IHostingEnvironment environment, IImageDAL imageDAL, GoogleCloudStorage cloudStorage)
        {
            this.environment = environment;
            this.imageDAL = imageDAL;
            this.cloudStorage = cloudStorage;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post(ImageUpload upload)
        {
            string location = "";
            string fileName = upload.File.FileName;

            cloudStorage.Connect();

            string localFileLocation = $"{environment.WebRootPath}\\uploads\\{fileName}";
            using (FileStream fs = System.IO.File.Create(localFileLocation))
            {
                upload.File.CopyTo(fs);
                fs.Flush();
                location = cloudStorage.UploadFile(fs);
            }
            System.IO.File.Delete(localFileLocation);

            imageDAL.AssignImageLocationToRecipe(location, new Recipe() { ID = Convert.ToInt32(upload.RecipeId) });

            return Json(location);
        }

        [HttpDelete]
        public void Delete(int recipeId, string filename)
        {
            filename = cloudStorage.DeleteFile(filename);

            imageDAL.Remove(recipeId, filename);
        }
    }
}
