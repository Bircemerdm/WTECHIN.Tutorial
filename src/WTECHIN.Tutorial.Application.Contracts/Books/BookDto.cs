using System;
using Volo.Abp.Application.Dtos;

namespace WTECHIN.Tutorial.Books;

public class BookDto : AuditedEntityDto<Guid> 
{
    public string Name { get; set; }
    public BookType Type { get; set; }
    public DateTime PublishDate { get; set; }
    public float Price { get; set; }

}
//DTO Gereksiz verileri gizler (örneğin, tüm Entity nesnesini göndermek yerine sadece ihtiyacın olan verileri içerir).
//Veritabanı modelini doğrudan API'ye açmamak için kullanılır.
//Kullanıcıya sadece gerekli verileri göndermeye olanak tanır.
