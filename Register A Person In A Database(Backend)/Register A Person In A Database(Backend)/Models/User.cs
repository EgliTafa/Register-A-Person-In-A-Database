using Microsoft.AspNetCore.Identity;
using Register_A_Person_In_A_Database_Backend_.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Register_A_Person_In_A_Database_Backend_.Models
{
    public class User : IdentityUser
    {
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [MaxLength(60)]
        public string? LastName { get; set; }
        public Roles Role { get; set; } = Roles.NormalUser;
    }
}
