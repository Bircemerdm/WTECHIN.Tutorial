using WTECHIN.Tutorial.Samples;
using Xunit;

namespace WTECHIN.Tutorial.EntityFrameworkCore.Applications;

[Collection(TutorialTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TutorialEntityFrameworkCoreTestModule>
{

}
