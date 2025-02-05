using WTECHIN.Tutorial.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace WTECHIN.Tutorial.Web.Pages;

public abstract class TutorialPageModel : AbpPageModel
{
    protected TutorialPageModel()
    {
        LocalizationResourceType = typeof(TutorialResource);
    }
}
