using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models.Email
{
    public class FamilyRoleEmail
    {
        public User User { get; set; }
        public string PreviousRole { get; set; }
        public User UserWhoMadeChange { get; set; }
        public Family Family {get; set;}
    }
}
