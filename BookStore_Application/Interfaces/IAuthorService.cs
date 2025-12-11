using BookStore.Application.DTOs;
using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(Guid id);
        Task<AuthorDto> CreateAsync(CreateAuthorDto dto);
        Task UpdateAsync(Guid id,UpdateAuthorDto dto);
        Task DeleteAsync(Guid id);
    }
}
