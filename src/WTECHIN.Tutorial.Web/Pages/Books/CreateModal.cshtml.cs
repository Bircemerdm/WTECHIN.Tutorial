using System.Threading.Tasks;//Task kullanarak asenkron (async) iþlemleri yönetmek için gerekli.
using WTECHIN.Tutorial.Books; //Kitaplarla ilgili servisler (IBookAppService) ve DTO'lar (CreateUpdateBookDto) burada tanýmlý.
using Microsoft.AspNetCore.Mvc;//BindProperty, IActionResult gibi ASP.NET Core özelliklerini kullanmak için eklenmiþ.


namespace WTECHIN.Tutorial.Web.Pages.Books
{
    public class CreateModalModel : TutorialPageModel
    {
        [BindProperty]//[BindProperty] özelliði sayesinde formdan gelen verileri otomatik olarak alýyor.Kullanýcý modalda formu doldurduðunda Book nesnesine otomatik olarak baðlanýyor.

        public CreateUpdateBookDto Book { get; set; } //Book adlý bir DTO nesnesini tanýmlýyor.

        private readonly IBookAppService _bookAppService;
        //içinde kitap oluþturma iþlemini yapabilmek için bu  ýnterface servise ihtiyacýmýz var çünkü crud iþlemlerini tanýmladýk. 
        //_bookAppService Kitap oluþturma, listeleme, güncelleme ve silme iþlemlerini yapar.
        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }
        //_bookAppService deðiþkenini baþlatmak ve baðýmlýlýðý enjekte etmek için.IBookAppService nesnesini otomatik olarak oluþturup enjekte ediyor.
        public void OnGet() //Sayfa ilk açýldýðýnda çalýþan metottur. kullanýcý modalý açtýðýnda çalýþýr
        {
            Book = new CreateUpdateBookDto(); //Boþ bir CreateUpdateBookDto nesnesi oluþturur.Kullanýcý modalý açýnca formda boþ bir kitap ekleme alaný görünür.
        }

        public async Task<IActionResult> OnPostAsync() //Kullanýcý formu gönderdiðinde (POST isteði) çalýþýr.
        {
            await _bookAppService.CreateAsync(Book);
            //_bookAppService servisini kullanarak veriyi veritabanýna ekler.
            return NoContent(); //Baþarýlý olursa 204 (No Content) HTTP yanýtý döndürür.Sayfanýn yenilenmesine gerek kalmaz (JavaScript modalý kapatabilir).
        }
    }
}
