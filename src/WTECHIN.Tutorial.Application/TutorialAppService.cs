using WTECHIN.Tutorial.Localization;
using Volo.Abp.Application.Services;

namespace WTECHIN.Tutorial;

/* Inherit your application services from this class.
 */
public abstract class TutorialAppService : ApplicationService
{
    protected TutorialAppService()
    {
        LocalizationResource = typeof(TutorialResource);
    }
}
