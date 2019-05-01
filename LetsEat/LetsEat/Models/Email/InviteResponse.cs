using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models.Email
{
    public class InviteResponse
    {
        public User Invitee { get; set; }

        public User Inviter { get; set; }

        public Family Family { get; set; }
    }
}
