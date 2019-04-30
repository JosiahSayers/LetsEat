using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models.Forms
{
    public class DenyWebsiteRequest
    {
        public WebsiteRequest WebsiteRequest { get; set; }

        public User Admin { get; set; }

        [Required]
        [MinLength(50)]
        public string Message { get; set; }
    }
}
