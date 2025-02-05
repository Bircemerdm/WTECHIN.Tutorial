using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using WTECHIN.Tutorial.Localization;

namespace WTECHIN.Tutorial.Web;

[Dependency(ReplaceServices = true)]
public class TutorialBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TutorialResource> _localizer;

    public TutorialBrandingProvider(IStringLocalizer<TutorialResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
