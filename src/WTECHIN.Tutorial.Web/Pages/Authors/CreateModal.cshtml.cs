using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WTECHIN.Tutorial.Authors;

namespace WTECHIN.Tutorial.Web.Pages.Authors;

public class CreateModalModel : TutorialPageModel
{{
        [BindProperty]
        public CreateAuthorViewModel Author { get; set; }

    private readonly IAuthorAppService _authorAppService;

    public CreateModalModel(IAuthorAppService authorAppService)
    {
        _authorAppService = authorAppService;
    }

    public void OnGet()
    {
        Author = new CreateAuthorViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateAuthorViewModel, CreateAuthorDto>(Author);
        await _authorAppService.CreateAsync(dto);
        return NoContent();
    }

    public class CreateAuthorViewModel
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [TextArea]
        public string? ShortBio { get; set; }
    }
}