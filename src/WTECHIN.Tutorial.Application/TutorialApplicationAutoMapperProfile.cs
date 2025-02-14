using System.Runtime.ConstrainedExecution;
using AutoMapper;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial;

public class TutorialApplicationAutoMapperProfile : Profile
{
    public TutorialApplicationAutoMapperProfile()
    {
//        Bu, Book nesnesini otomatik olarak BookDto nesnesine çevirmek için bir kural oluþturur.Bu sayede:Book nesnesindeki ayný isimdeki property'ler otomatik olarak BookDto'ya taþýnýr.
//Manuel olarak new BookDto { Name = book.Name, Price = book.Price } yazmamýza gerek kalmaz.

        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
// AutoMapper, bir nesneyi baþka bir nesneye otomatik olarak eþlemeyi(map) saðlayan bir kütüphanedir.
// Neden Kullanýyoruz?
// Kod tekrarýný azaltýr(Her yerde new BookDto { } yazmak yerine tek bir taným yaparýz).
// Veri dönüþümlerini merkezi hale getirir(Tüm mapping iþlemleri tek bir yerde tanýmlanýr).
// Bakýmý kolaylaþtýrýr(Bir alan eklediðinde sadece burada deðiþtirmen yeterlidir).
    }
}
