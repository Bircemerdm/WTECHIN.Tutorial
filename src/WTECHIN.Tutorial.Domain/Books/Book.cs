using System; //C#’ın temel sistem kütüphanesini içeri aktarıyor. DateTime gibi temel veri türlerini kullanabilmemizi sağlıyor.
using Volo.Abp.Domain.Entities.Auditing; //ABP.IO’nun audit (denetim) özelliklerini içeren kütüphanesini kullanıyoruz.AuditedAggregateRoot<Guid> sınıfını içeri aktarıyor.

namespace WTECHIN.Tutorial.Books;


    public class Book : AuditedAggregateRoot<Guid>//kullanarak Book varlığının benzersiz bir Guid kimliği olmasını sağlıyoruz.Veritabanında her kitap, otomatik olarak bir Guid ile tanımlanacak.
{//ad alanı içinde Book sınıfını oluşturuyoruz. Başka bir sınıf bu kodu kullanacaksa, bu namespace’i referans göstermelidir.
 //sınıfından kalıtım (inheritance) alıyor.
        public string Name { get; set; }
        public BookType Type {  get; set; } //enum ları diğer katmanlarla paylaşmak istediğim için domain shared tarafına koymalıyım
        public DateTime PublishDate {  get; set; }
        public float Price { get; set; }

}
