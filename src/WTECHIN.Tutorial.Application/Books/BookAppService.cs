using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace WTECHIN.Tutorial.Books;
public class BookAppService :
    CrudAppService<
        Book, //The Book entity Kitabın Entity sınıfı
        BookDto, //Used to show books  Kitap bilgilerini döndürmek için kullanılan DTO
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService IBookAppService arayüzünü uyguluyor
{
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {
        //IRepository<Book, Guid> repository → ABP’nin IRepository arayüzü sayesinde veritabanına erişimi sağladık.
        //base(repository) → CrudAppService sınıfına bu repository’yi ilettik, böylece CRUD işlemleri için veri erişimi sağlandı.

    }
}

