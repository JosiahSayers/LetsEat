using System.ComponentModel.DataAnnotations;

namespace LetsEat.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public bool IsAdmin
        {
            get
            {
                return Role == "Admin";
            }
        }

        /// <summary>
        /// The user's role.
        /// </summary>
        public string Role { get; set; }

        public int FamilyId { get; set; }

        public string FamilyRole { get; set; }
    }
}
