using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial.Web.Pages.Books
{
    public class IndexModel : AbpPageModel
    {
        protected IBookAppService _booksAppService;

        public IndexModel(IBookAppService booksAppService)
        {
            _booksAppService = booksAppService;
        }

        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}