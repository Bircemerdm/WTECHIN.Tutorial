using AutoMapper;
using WTECHIN.Tutorial.Authors;
using WTECHIN.Tutorial.Books;
using WTECHIN.Tutorial.Web.Pages.Authors;
using WTECHIN.Tutorial.Web.Pages.Books;

namespace WTECHIN.Tutorial.Web;

public class TutorialWebAutoMapperProfile : Profile
{
    public TutorialWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project
        //Web projesi için nesne eklemelerinizi burada tanımlayın
        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<BookDto, BookUpdateViewModel>();
        CreateMap<BookUpdateViewModel, CreateUpdateBookDto>();
        CreateMap<AuthorDto, AuthorCreateViewModel>();
        CreateMap<AuthorDto, AuthorUpdateViewModel>();
        CreateMap<AuthorCreateViewModel, CreateAuthorDto>();
        CreateMap<AuthorUpdateViewModel, UpdateAuthorDto>();
    }
}
