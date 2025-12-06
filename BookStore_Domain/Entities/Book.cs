using BookStore.Domain.Common;

namespace BookStore.Domain.Entities
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Slog { get; set; }
    }
}
