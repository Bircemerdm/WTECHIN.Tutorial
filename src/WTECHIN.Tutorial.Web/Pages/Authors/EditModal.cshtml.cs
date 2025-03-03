using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using WTECHIN.Tutorial.Authors;

namespace WTECHIN.Tutorial.Web.Pages.Authors
{
    public class EditModalModel : TutorialPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public AuthorUpdateViewModel Author { get; set; }

        protected IAuthorAppService _authorAppService;

        public EditModalModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;

            Author = new();
        }

        public virtual async Task OnGetAsync()
        {
            var authorDto = await _authorAppService.GetAsync(Id);
            Author = ObjectMapper.Map<AuthorDto, AuthorUpdateViewModel>(authorDto);
        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _authorAppService.UpdateAsync(Id, ObjectMapper.Map<AuthorUpdateViewModel, UpdateAuthorDto>(Author));
            return NoContent();
        }
    }

    public class AuthorUpdateViewModel : UpdateAuthorDto
    {
    }
}