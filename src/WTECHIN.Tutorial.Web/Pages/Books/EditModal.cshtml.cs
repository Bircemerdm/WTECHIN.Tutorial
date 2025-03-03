using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial.Web.Pages.Books
{
    public class EditModalModel : TutorialPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public BookUpdateViewModel Book { get; set; }

        protected IBookAppService _bookAppService;

        public EditModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;

            Book = new();
        }

        public virtual async Task OnGetAsync()
        {
            var bookDto = await _bookAppService.GetAsync(Id);
            Book = ObjectMapper.Map<BookDto, BookUpdateViewModel>(bookDto);
        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {   
            await _bookAppService.UpdateAsync(Id, ObjectMapper.Map<BookUpdateViewModel, CreateUpdateBookDto>(Book));
            return NoContent();
        }
    }

    public class BookUpdateViewModel : CreateUpdateBookDto
    {
    }
}