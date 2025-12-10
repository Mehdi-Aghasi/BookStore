using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IReadOnlyList<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
        Task<IEnumerable<Book>> GetByAuthorAsync(string author);
        Task<IEnumerable<Book>> GetByCategoryAsync(string category);
    }
}
