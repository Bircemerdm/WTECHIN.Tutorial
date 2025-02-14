using System.Threading.Tasks;//Task kullanarak asenkron (async) i�lemleri y�netmek i�in gerekli.
using WTECHIN.Tutorial.Books; //Kitaplarla ilgili servisler (IBookAppService) ve DTO'lar (CreateUpdateBookDto) burada tan�ml�.
using Microsoft.AspNetCore.Mvc;//BindProperty, IActionResult gibi ASP.NET Core �zelliklerini kullanmak i�in eklenmi�.


namespace WTECHIN.Tutorial.Web.Pages.Books
{
    public class CreateModalModel : TutorialPageModel
    {
        [BindProperty]//[BindProperty] �zelli�i sayesinde formdan gelen verileri otomatik olarak al�yor.Kullan�c� modalda formu doldurdu�unda Book nesnesine otomatik olarak ba�lan�yor.

        public CreateUpdateBookDto Book { get; set; } //Book adl� bir DTO nesnesini tan�ml�yor.

        private readonly IBookAppService _bookAppService;
        //i�inde kitap olu�turma i�lemini yapabilmek i�in bu  �nterface servise ihtiyac�m�z var ��nk� crud i�lemlerini tan�mlad�k. 
        //_bookAppService Kitap olu�turma, listeleme, g�ncelleme ve silme i�lemlerini yapar.
        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }
        //_bookAppService de�i�kenini ba�latmak ve ba��ml�l��� enjekte etmek i�in.IBookAppService nesnesini otomatik olarak olu�turup enjekte ediyor.
        public void OnGet() //Sayfa ilk a��ld���nda �al��an metottur. kullan�c� modal� a�t���nda �al���r
        {
            Book = new CreateUpdateBookDto(); //Bo� bir CreateUpdateBookDto nesnesi olu�turur.Kullan�c� modal� a��nca formda bo� bir kitap ekleme alan� g�r�n�r.
        }

        public async Task<IActionResult> OnPostAsync() //Kullan�c� formu g�nderdi�inde (POST iste�i) �al���r.
        {
            await _bookAppService.CreateAsync(Book);
            //_bookAppService servisini kullanarak veriyi veritaban�na ekler.
            return NoContent(); //Ba�ar�l� olursa 204 (No Content) HTTP yan�t� d�nd�r�r.Sayfan�n yenilenmesine gerek kalmaz (JavaScript modal� kapatabilir).
        }
    }
}
