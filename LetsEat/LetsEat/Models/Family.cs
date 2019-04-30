using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models
{
    public class Family
    {
        public int Id { get; set; }
        public List<User> Members { get; set; }

        [Display(Name = "Family Name")]
        [Required]
        public string Name { get; set; }
    }
}
