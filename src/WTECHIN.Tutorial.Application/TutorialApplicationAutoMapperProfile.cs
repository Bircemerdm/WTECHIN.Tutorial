using System.Runtime.ConstrainedExecution;
using AutoMapper;
using WTECHIN.Tutorial.Authors;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial;

public class TutorialApplicationAutoMapperProfile : Profile
{
    public TutorialApplicationAutoMapperProfile()
    {
//        Bu, Book nesnesini otomatik olarak BookDto nesnesine �evirmek i�in bir kural olu�turur.Bu sayede:Book nesnesindeki ayn� isimdeki property'ler otomatik olarak BookDto'ya ta��n�r.
//Manuel olarak new BookDto { Name = book.Name, Price = book.Price } yazmam�za gerek kalmaz.

        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>(); 
        
        CreateMap<Author, AuthorDto>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
// AutoMapper, bir nesneyi ba�ka bir nesneye otomatik olarak e�lemeyi(map) sa�layan bir k�t�phanedir.
// Neden Kullan�yoruz?
// Kod tekrar�n� azalt�r(Her yerde new BookDto { } yazmak yerine tek bir tan�m yapar�z).
// Veri d�n���mlerini merkezi hale getirir(T�m mapping i�lemleri tek bir yerde tan�mlan�r).
// Bak�m� kolayla�t�r�r(Bir alan ekledi�inde sadece burada de�i�tirmen yeterlidir).
    }
}
