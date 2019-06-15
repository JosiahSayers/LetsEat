using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models
{
    public class Invite
    {
        public int Id { get; set; }
        public int Invitee { get; set; }
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public User InvitedBy { get; set; }
    }
}
