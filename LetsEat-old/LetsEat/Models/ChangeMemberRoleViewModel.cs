using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsEat.Models
{
    public class ChangeMemberRoleViewModel
    {
        public User userToChange { get; set; }
        public IEnumerable<SelectListItem> Roles
        {
            get
            {
                List<SelectListItem> roles = new List<SelectListItem>();
                roles.Add(new SelectListItem() { Disabled = true, Text = "Choose a role..." });
                roles.Add(new SelectListItem() { Text = "Leader", Value = "Leader" });
                roles.Add(new SelectListItem() { Text = "Member", Value = "Member" });
                return roles;
            }
        }
    }
}
