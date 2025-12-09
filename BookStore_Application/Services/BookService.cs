using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        //private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> CreateAsync(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                Description = dto.Description,
                Stock = dto.Stock,
                Price = dto.Price,
            };
            //var book=_mapper.Map<Book>(dto);
            await _bookRepository.AddBookAsync(book);
            //return _mapper.Map<BookDto>(book);
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Description = book.Description,
                Stock = book.Stock,
                Price = book.Price,
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new KeyNotFoundException($"Book with ID {id} not found.");

            await _bookRepository.DeleteBookAsync(book);
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            IEnumerable<Book> books = await _bookRepository.GetAllAsync();
            var booksDto = books.Select(t => new BookDto
            {
                Id = t.Id,
                Title = t.Title,
                Author = t.Author,
                ISBN = t.ISBN,
                Description = t.Description,
                Stock = t.Stock,
                Price = t.Price,
            });
            return booksDto;
        }

        public async Task<IEnumerable<BookDto>> GetByAuthorAsync(string author)
        {
            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentNullException(nameof(author));
            }
            var books = await _bookRepository.GetByAuthorAsync(author);
            var booksDto = books.Select(t => new BookDto
            {
                Id = t.Id,
                Title = t.Title,
                Author = t.Author,
                ISBN = t.ISBN,
                Description = t.Description,
                Stock = t.Stock,
                Price = t.Price,
            });

            return booksDto;
        }

        public async Task<BookDto> GetByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new KeyNotFoundException($"Book with Id {id} not found");

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Description = book.Description,
                Stock = book.Stock,
                Price = book.Price,
            };
        }

        public async Task<BookDto> UpdateAsync(Guid id, UpdateBookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with Id {id} not found");
            }
            if (!string.IsNullOrEmpty(dto.Title)) book.Title = dto.Title;
            if (!string.IsNullOrEmpty(dto.Author)) book.Author = dto.Author;
            if (!string.IsNullOrEmpty(dto.Description)) book.Description = dto.Description;
            if (!string.IsNullOrEmpty(dto.ISBN)) book.ISBN = dto.ISBN;
            if (dto.Price.HasValue) book.Price = dto.Price.Value;
            if (dto.Stock.HasValue) book.Stock = dto.Stock.Value;
            await _bookRepository.UpdateBookAsync(book);
            return new BookDto
            {
                Title=book.Title,
                Author=book.Author,
                ISBN=book.ISBN,
                Description=book.Description,
                Price=book.Price,
                Stock=book.Stock,
            };
        }
    }
}
