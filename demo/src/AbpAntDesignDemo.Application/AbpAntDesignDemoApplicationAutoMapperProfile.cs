using AbpAntDesignDemo.Authors;
using AbpAntDesignDemo.Books;
using AutoMapper;

namespace AbpAntDesignDemo
{
    public class AbpAntDesignDemoApplicationAutoMapperProfile : Profile
    {
        public AbpAntDesignDemoApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorLookupDto>();
        }
    }
}
