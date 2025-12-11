using Azure.Core;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _context;

        public AuthorRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthorAsync(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            var existing = await _context.Authors.FirstOrDefaultAsync(a => a.Id == author.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Author with Id {author.Id} not found");

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Author>> GetAllAuthorAsync()
        {
            var authors = await _context.Authors.AsNoTracking().ToListAsync();
            return authors;
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            return await _context.Authors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var existing = await _context.Authors.FirstOrDefaultAsync(y => y.Id == author.Id);
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            existing.Name = author.Name;
            existing.Bio = author.Bio;
            existing.Age = author.Age;
            await _context.SaveChangesAsync();
        }
    }
}
