using WTECHIN.Tutorial.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace WTECHIN.Tutorial.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TutorialController : AbpControllerBase
{
    protected TutorialController()
    {
        LocalizationResource = typeof(TutorialResource);
    }
}
