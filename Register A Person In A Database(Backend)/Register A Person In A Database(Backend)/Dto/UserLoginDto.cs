using System.ComponentModel.DataAnnotations;

namespace Register_A_Person_In_A_Database_Backend_.Dto
{
    public class UserLoginDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
