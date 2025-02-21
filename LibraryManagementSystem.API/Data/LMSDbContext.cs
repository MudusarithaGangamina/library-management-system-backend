using LibraryManagementSystem.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Data
{
    public class LMSDbContext: DbContext
    {
        public LMSDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Cricket",
                    Author = "Kusal Mendis",
                    Description = "Cricket is Life"
                },
                new Book
                {
                    Id = 2,
                    Title = "Football",
                    Author = "Lionel Messi",
                    Description = "Football is Life"
                }
            );
        }
    }
}
