namespace BookStore.Application.DTOs
{
    public class CategoryDto
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
