using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models.Email
{
    public class RemoveFromFamilyEmail
    {
        public User User { get; set; }
        public User Leader { get; set; }
        public Family Family { get; set; }
    }
}
