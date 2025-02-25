namespace LibraryManagementSystem.API.Models.DTO
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
