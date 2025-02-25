using LibraryManagementSystem.API.Models.Domain;
using LibraryManagementSystem.API.Models.DTO;
using System.Runtime.InteropServices;

namespace LibraryManagementSystem.API.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(int id);

        Task<Book> CreateAsync(Book book);

        Task<Book?> UpdateAsync(int id, Book book);

        Task<Book?> DeleteAsync(int id);
    }
}
