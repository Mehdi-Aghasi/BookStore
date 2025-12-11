using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IReadOnlyList<Author>> GetAllAuthorAsync();
        Task<Author> GetByIdAsync(Guid id);
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(Author author);
    }
}
