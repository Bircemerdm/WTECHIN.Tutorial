using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTECHIN.Tutorial.Authors;

namespace WTECHIN.Tutorial.Web.Pages.Authors
{
    public class CreateModalModel : TutorialPageModel
    {

        [BindProperty]
        public AuthorCreateViewModel Author { get; set; }
        
        protected IAuthorAppService _authorAppService;

        public CreateModalModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;

            Author = new();
        }

        public virtual async Task OnGetAsync()
        {
            Author = new AuthorCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _authorAppService.CreateAsync(ObjectMapper.Map<AuthorCreateViewModel, CreateAuthorDto>(Author));
            return NoContent();
        }
    }

    public class AuthorCreateViewModel : CreateAuthorDto
    {
    }
}