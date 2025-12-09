using BookStore.Application.DTOs;

namespace BookStore.Application.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task<BookDto> GetByIdAsync(Guid id);
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> UpdateAsync(Guid id, UpdateBookDto dto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<BookDto>> GetByAuthorAsync(string author);
    }
}
