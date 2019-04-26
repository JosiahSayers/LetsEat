using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models.Forms
{
    public class AddFamilyMemberForm
    {
        public User CurrentUser { get; set; }
        public User NewMember { get; set; }

        [Display(Name= "Search for a current user by their email and invite them to join your family")]
        [EmailAddress]
        public string SearchEmail { get; set; }
    }
}
