using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace WTECHIN.Tutorial.Books;
public interface IBookAppService :
    ICrudAppService< //Defines CRUD methods
        BookDto, //Used to show books Kitapları gösterirken kullanılacak DTO
        Guid, //Primary key of the book entity  Kitap entity’sinin Primary Key türü 
        PagedAndSortedResultRequestDto, //Used for paging/sorting Sayfalama ve sıralama için kullanılacak DTO
        CreateUpdateBookDto> //Used to create/update a book Kitap oluşturma/güncelleme için kullanılacak DTO
{

}
