using BookStore.Domain.Common;

namespace BookStore.Domain.Entities
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Slug { get; set; }
        public Guid  CategoryId { get; set; }
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
