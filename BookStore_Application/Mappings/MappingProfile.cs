using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Domain.Entities;

namespace BookStore.Application.Mappings
{
    public class MappingProfile : Profile
    {
        MappingProfile()
        {
            CreateMap<CreateBookDto,Book>();
            CreateMap<UpdateBookDto,Book>();
            CreateMap<Book,BookDto>();
        }
    }
}
