using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;

namespace BookStore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorDto> CreateAsync(CreateAuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name,
                Bio = dto.Bio,
                Age = dto.Age,
            };
            await _repository.AddAuthorAsync(author);

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio,
                Age = author.Age,
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var author = await _repository.GetByIdAsync(id);
            if (author == null)
                throw new KeyNotFoundException($"Author with ID {id} not found.");

            await _repository.DeleteAuthorAsync(author);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _repository.GetAllAuthorAsync();
            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                Bio = a.Bio,
                Age = a.Age
            });
        }

        public async Task<AuthorDto> GetByIdAsync(Guid id)
        {
            var author = await _repository.GetByIdAsync(id);
            if (author == null)
                throw new KeyNotFoundException($"Author with ID {id} not found.");

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio,
                Age = author.Age
            };
        }

        public async Task UpdateAsync(Guid id, UpdateAuthorDto dto)
        {
            var author = await _repository.GetByIdAsync(id);
            if (author == null)
                throw new KeyNotFoundException($"Author with ID {id} not found.");

            if (!string.IsNullOrEmpty(dto.Name)) author.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.Bio)) author.Bio = dto.Bio;

            await _repository.UpdateAuthorAsync(author);
        }
    }
}
