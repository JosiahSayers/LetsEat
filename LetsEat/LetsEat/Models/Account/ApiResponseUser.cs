using System;
namespace LetsEat.Models.Account
{
    public class ApiResponseUser
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public string Role { get; set; }

        public int FamilyId { get; set; }

        public string FamilyRole { get; set; }

        public Invite Invite { get; set; }

        public bool InviteRequest { get; set; }

        public ApiResponseUser(User user)
        {
            Id = user.Id;
            DisplayName = user.DisplayName;
            Email = user.Email;
            IsAdmin = user.IsAdmin;
            Role = user.Role;
            FamilyId = user.FamilyId;
            FamilyRole = user.FamilyRole;
            Invite = user.Invite;
            InviteRequest = user.InviteRequest;
        }  
    }
}
