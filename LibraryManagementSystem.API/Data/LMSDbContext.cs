using LibraryManagementSystem.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Data
{
    public class LMSDbContext: DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        
    }
}
