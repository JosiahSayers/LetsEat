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
using LetsEat.Providers.Storage;
using LetsEat.Providers.Auth;
using LetsEat.Models.Image;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsEat.Controllers.API
{
    [Route("api/v1/[controller]")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment environment;
        private readonly IImageDAL imageDAL;
        private readonly GoogleCloudStorage cloudStorage;
        private readonly ApiAuthProvider authProvider;
        private readonly ImageErrorMessages error = new ImageErrorMessages();

        public ImageController(
            IHostingEnvironment environment,
            IImageDAL imageDAL,
            GoogleCloudStorage cloudStorage,
            ApiAuthProvider authProvider
            )
        {
            this.environment = environment;
            this.imageDAL = imageDAL;
            this.cloudStorage = cloudStorage;
            this.authProvider = authProvider;
        }

        [HttpPost]
        public IActionResult Post(ImageUpload upload)
        {
            ObjectResult output = StatusCode(401, error.NotLoggedIn);

            if (authProvider.IsLoggedIn)
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

                output = StatusCode(200, location);
            }


            return output;
        }

        [HttpDelete]
        public void Delete(int recipeId, string filename)
        {
            if (authProvider.IsLoggedIn)
            {
                if (imageDAL.DoesUserOwnImage(authProvider.GetCurrentUser()))
                {
                    filename = cloudStorage.DeleteFile(filename);

                    imageDAL.Remove(recipeId, filename);
                }
            }
        }
    }
}
