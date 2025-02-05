using Volo.Abp.Modularity;

namespace WTECHIN.Tutorial;

public abstract class TutorialApplicationTestBase<TStartupModule> : TutorialTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
