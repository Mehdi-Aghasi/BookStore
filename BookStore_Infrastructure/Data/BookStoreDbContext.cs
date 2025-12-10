using BookStore.Domain.Entities;
using BookStore.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data
{
    public class BookStoreDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
