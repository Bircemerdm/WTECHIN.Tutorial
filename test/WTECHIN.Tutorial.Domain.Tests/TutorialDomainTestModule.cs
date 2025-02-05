using Volo.Abp.Modularity;

namespace WTECHIN.Tutorial;

[DependsOn(
    typeof(TutorialDomainModule),
    typeof(TutorialTestBaseModule)
)]
public class TutorialDomainTestModule : AbpModule
{

}
