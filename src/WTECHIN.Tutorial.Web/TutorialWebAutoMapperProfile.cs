using AutoMapper;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial.Web;

public class TutorialWebAutoMapperProfile : Profile
{
    public TutorialWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project
        //Web projesi için nesne eşlemelerinizi burada tanımlayın
        CreateMap<BookDto, CreateUpdateBookDto>();
    }
}
