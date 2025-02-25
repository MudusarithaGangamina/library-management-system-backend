using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
