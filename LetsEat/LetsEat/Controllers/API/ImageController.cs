using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LetsEat.Controllers.API
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment environment;

        public ImageController(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]IFormFile image)
        {
            try
            {
                if (!Directory.Exists(environment.WebRootPath + "\\uploads\\"))
                {
                    Directory.CreateDirectory(environment.WebRootPath + "\\uploads\\");
                }

                using (FileStream fs = System.IO.File.Create(environment.WebRootPath + "\\uploads\\" + image.FileName))
                {
                    image.CopyTo(fs);
                    fs.Flush();
                    return "\\uploads\\" + image.FileName;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
