using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _context;

        public CategoryRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            var res = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (res == null)
            {
                throw new KeyNotFoundException("category not found");
            }
            _context.Remove(res);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();

        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> GetBySlugAsync(string slug)
        {
            return await _context.Categories.AsNoTracking().Where(x=>x.Slug== slug).FirstOrDefaultAsync();
        }

        public async Task<Category?> GetCategoryWithBooksAsync(Guid id)
        {
            return await _context.Categories/*.Include(t=>t.Books)*/.AsNoTracking().Where(x=>x.Id== id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            var exist=await _context.Categories.FirstOrDefaultAsync(c=>c.Id==category.Id);
            if (exist == null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            exist.Name = category.Name;
            exist.Description = category.Description;
            exist.Slug = category.Slug;
            await _context.SaveChangesAsync();
        }
    }
}
