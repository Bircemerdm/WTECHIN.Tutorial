using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial.Web.Pages.Books
{
    public class EditModalModel : TutorialPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)] //GET isteðinde (OnGetAsync) bu deðerin baðlanmasýný saðlar.
        public Guid Id { get; set; }

      

        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }

        private readonly IBookAppService _bookAppService;

        public EditModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public async Task OnGetAsync() //Get isteðini çaðýran bir kod ismini deðiþtirme
        {
            var bookDto = await _bookAppService.GetAsync(Id);
            Book = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto); //<TSource, TDestination>(source).bookDto nesnesi CreateUpdateBookDto türüne dönüþtürülür (mapping iþlemi).Dönüþtürülen veri Book deðiþkenine atanýr ? HTML formunda gösterilecektir.
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.UpdateAsync(Id, Book);
            return NoContent();
        }
    }
}
