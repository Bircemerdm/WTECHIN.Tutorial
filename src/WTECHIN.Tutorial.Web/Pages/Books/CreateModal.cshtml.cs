using System.Threading.Tasks;//Task kullanarak asenkron (async) işlemleri yönetmek için gerekli.
using WTECHIN.Tutorial.Books; //Kitaplarla ilgili servisler (IBookAppService) ve DTO'lar (CreateUpdateBookDto) burada tanımlı.
using Microsoft.AspNetCore.Mvc;//BindProperty, IActionResult gibi ASP.NET Core özelliklerini kullanmak için eklenmiş.


namespace WTECHIN.Tutorial.Web.Pages.Books
{
    public class CreateModalModel : TutorialPageModel
    {
        [BindProperty]//[BindProperty] özelliği sayesinde formdan gelen verileri otomatik olarak alıyor.Kullanıcı modalda formu doldurduğunda Book nesnesine otomatik olarak bağlanıyor.

        public CreateUpdateBookDto Book { get; set; } //Book adlı bir DTO nesnesini tanımlıyor.

        private readonly IBookAppService _bookAppService;
        //içinde kitap oluşturma işlemini yapabilmek için bu  ınterface servise ihtiyacımız var çünkü crud işlemlerini tanımladık. 
        //_bookAppService Kitap oluşturma, listeleme, güncelleme ve silme işlemlerini yapar.
        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }
        //_bookAppService değişkenini başlatmak ve bağımlılığı enjekte etmek için.IBookAppService nesnesini otomatik olarak oluşturup enjekte ediyor.
        public void OnGet() //Sayfa ilk açıldığında çalışan metottur. kullanıcı modalı açtığında çalışır
        {
            Book = new CreateUpdateBookDto(); //Boş bir CreateUpdateBookDto nesnesi oluşturur.Kullanıcı modalı açınca formda boş bir kitap ekleme alanı görünür.
        }

        public async Task<IActionResult> OnPostAsync() //Kullanıcı formu gönderdiğinde (POST isteği) çalışır.
        {
            await _bookAppService.CreateAsync(Book);
            //_bookAppService servisini kullanarak veriyi veritabanına ekler.
            return NoContent(); //Başarılı olursa 204 (No Content) HTTP yanıtı döndürür.Sayfanın yenilenmesine gerek kalmaz (JavaScript modalı kapatabilir).
        }
    }
}
