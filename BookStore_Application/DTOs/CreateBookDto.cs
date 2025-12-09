using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}

