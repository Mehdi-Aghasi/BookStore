using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;

namespace BookStore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Slug = dto.Slug,
                Description = dto.Description,
            };
            await _repository.AddAsync(category);
            return new CategoryDto
            {
                id=category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
            };
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {id} not foud");
            }
            await _repository.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(x => new CategoryDto
            {
                id= x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Description = x.Description,
            });
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {id} not foud");
            }
            return new CategoryDto
            {
                id=category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
            };
        }

        public async Task UpdateCategoryAsync(Guid id, UpdateCategoryDto dto)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {id} not foud");
            }
            category.Name = dto.Name;
            category.Description = dto.Description;
            category.Slug = dto.Slug;
            await _repository.UpdateAsync(category);
        }
    }
}
