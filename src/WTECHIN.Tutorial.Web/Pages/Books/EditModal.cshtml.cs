using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial.Web.Pages.Books
{
    public class EditModal : TutorialPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)] //GET iste�inde (OnGetAsync) bu de�erin ba�lanmas�n� sa�lar.
        public Guid Id { get; set; }

      

        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }

        private readonly IBookAppService _bookAppService;

        public EditModal(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public async Task OnGetAsync(Guid id) //Get iste�ini �a��ran bir kod ismini de�i�tirme
        {
            var bookDto = await _bookAppService.GetAsync(Id);
            Book = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto); //<TSource, TDestination>(source).bookDto nesnesi CreateUpdateBookDto t�r�ne d�n��t�r�l�r (mapping i�lemi).D�n��t�r�len veri Book de�i�kenine atan�r ? HTML formunda g�sterilecektir.
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.UpdateAsync(Id, Book);
            return NoContent();
        }
    }
}
