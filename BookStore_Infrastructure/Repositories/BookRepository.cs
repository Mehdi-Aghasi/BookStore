using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            var exist = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
            if (exist == null)
            {
                throw new KeyNotFoundException("Book not found");
            }
            _context.Books.Remove(exist);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Book>> GetAllAsync()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByAuthorAsync(string author)
        {
            var books = await _context.Books
         .AsNoTracking()
         .Where(x => x.Author == author)
         .ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> GetByCategoryAsync(string category)
        {
            var books = await _context.Books
        .AsNoTracking()
        .Where(x => x.Category == category)
        .ToListAsync();
            return books;
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateBookAsync(Book book)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException("Book not found");
            }
            existingBook.Title = book.Title;
            existingBook.ISBN = book.ISBN;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            existingBook.Stock = book.Stock;
            existingBook.Price = book.Price;
            existingBook.Category = book.Category;
            existingBook.Slog = book.Slog;
            await _context.SaveChangesAsync();
        }
    }
}
