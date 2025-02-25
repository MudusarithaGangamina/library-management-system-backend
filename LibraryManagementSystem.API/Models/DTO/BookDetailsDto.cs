﻿namespace LibraryManagementSystem.API.Models.DTO
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
