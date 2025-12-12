using BookStore.Application.DTOs;
using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
        Task<CategoryDto> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto);
        Task UpdateCategoryAsync(Guid id,UpdateCategoryDto dto);
        Task DeleteCategoryAsync(Guid id);
    }
}
