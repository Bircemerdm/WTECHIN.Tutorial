using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WTECHIN.Tutorial.Authors;

namespace WTECHIN.Tutorial.Web.Pages.Authors
{
    public class IndexModel : AbpPageModel
    {
        protected IAuthorAppService _authorsAppService;

        public IndexModel(IAuthorAppService authorsAppService)
        {
            _authorsAppService = authorsAppService;
        }

        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}