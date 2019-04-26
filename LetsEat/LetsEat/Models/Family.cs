using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models
{
    public class Family
    {
        public List<User> Members { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
