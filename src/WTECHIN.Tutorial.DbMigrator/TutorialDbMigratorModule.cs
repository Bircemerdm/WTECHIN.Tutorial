using WTECHIN.Tutorial.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace WTECHIN.Tutorial.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TutorialEntityFrameworkCoreModule),
    typeof(TutorialApplicationContractsModule)
)]
public class TutorialDbMigratorModule : AbpModule
{
}
