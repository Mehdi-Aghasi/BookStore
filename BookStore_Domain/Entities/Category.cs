using BookStore.Domain.Common;

namespace BookStore.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
