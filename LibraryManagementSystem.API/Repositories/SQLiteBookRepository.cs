using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.Models.Domain;
using LibraryManagementSystem.API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Repositories
{
    public class SQLiteBookRepository : IBookRepository
    {
        private readonly LMSDbContext dbContext;

        public SQLiteBookRepository(LMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var existingBook = await dbContext.Books.FindAsync(id);

            if (existingBook == null)
            {
                return null;
            }

            dbContext.Books.Remove(existingBook);
            await dbContext.SaveChangesAsync();
            return existingBook;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await dbContext.Books.FindAsync(id);
        }

        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            var existingBook = await dbContext.Books.FindAsync(id);

            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            existingBook.ImageUrl = book.ImageUrl;

            await dbContext.SaveChangesAsync();
            return existingBook;
        }
    }
}
