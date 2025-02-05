using Volo.Abp.Modularity;

namespace WTECHIN.Tutorial;

[DependsOn(
    typeof(TutorialApplicationModule),
    typeof(TutorialDomainTestModule)
)]
public class TutorialApplicationTestModule : AbpModule
{

}
