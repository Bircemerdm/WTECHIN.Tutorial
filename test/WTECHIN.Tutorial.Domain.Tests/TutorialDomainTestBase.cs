using Volo.Abp.Modularity;

namespace WTECHIN.Tutorial;

/* Inherit from this class for your domain layer tests. */
public abstract class TutorialDomainTestBase<TStartupModule> : TutorialTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
