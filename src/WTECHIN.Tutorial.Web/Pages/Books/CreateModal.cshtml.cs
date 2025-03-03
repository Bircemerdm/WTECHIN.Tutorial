using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial.Web.Pages.Books
{
    public class CreateModalModel : TutorialPageModel
    {

        [BindProperty]
        public BookCreateViewModel Book { get; set; }
        
        protected IBookAppService _bookAppService;

        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;

            Book = new();
        }

        public virtual async Task OnGetAsync()
        {
            Book = new BookCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(ObjectMapper.Map<BookCreateViewModel, CreateUpdateBookDto>(Book));
            return NoContent();
        }
    }

    public class BookCreateViewModel : CreateUpdateBookDto
    {
    }
}