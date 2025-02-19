using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace WTECHIN.Tutorial.Authors;

public class Author:FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string ShortBio { get; set; }
    private Author()
    {
      // ORM'nin (EF Core gibi) nesneyi veri tabanından çekerken veya JSON'dan deserialize ederken kullanabilmesi için gereklidir.
        /* This constructor is for deserialization / ORM purpose */
    }
    internal Author( //Bu Author sınıfının constructor'ıdır.internal erişim belirleyicisi, bu constructor'ın sadece aynı proje veya derlemeden erişilebileceğini belirtir. Parametreli Constructor
        Guid id, 
        string name,
        DateTime birthDate,
        string? shortBio = null)
        : base(id) //Base sınıf (FullAuditedAggregateRoot<Guid>) içindeki constructor'ı çağırır ve id parametresini ona iletir.
    {
        SetName(name);//bir metodu çağırarak, name değerini ayarlamak için kullanılıyor.  Doğrulama (validation) içerir.
        BirthDate = birthDate;
        ShortBio = shortBio;
    }
    internal Author ChangeName(string name) //İsmi değiştirmek için kullanılır.
    {
        SetName(name);
        return this;
    }
    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,  
            nameof(name), // parametrelerin adını string olarak döndürür
            maxLength: AuthorConsts.MaxNameLength
        );
    }

    
}