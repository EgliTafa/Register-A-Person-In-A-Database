using Register_A_Person_In_A_Database_Backend_.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Register_A_Person_In_A_Database_Backend_.Dto
{
    public class UserRegistrationDto
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public Roles Role { get; set; }
    }
}
