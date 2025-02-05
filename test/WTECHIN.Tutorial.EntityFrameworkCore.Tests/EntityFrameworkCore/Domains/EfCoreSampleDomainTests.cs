using WTECHIN.Tutorial.Samples;
using Xunit;

namespace WTECHIN.Tutorial.EntityFrameworkCore.Domains;

[Collection(TutorialTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TutorialEntityFrameworkCoreTestModule>
{

}
