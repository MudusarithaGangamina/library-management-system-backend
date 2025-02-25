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
        public string Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
