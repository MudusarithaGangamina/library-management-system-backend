using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.Models.DTO
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage ="Author Name cannot be higher than 30 characters.")]
        public string Author { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Description cannot be higher than 200 characters.")]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
