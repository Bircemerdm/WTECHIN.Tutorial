using Xunit;

namespace WTECHIN.Tutorial.EntityFrameworkCore;

[CollectionDefinition(TutorialTestConsts.CollectionDefinitionName)]
public class TutorialEntityFrameworkCoreCollection : ICollectionFixture<TutorialEntityFrameworkCoreFixture>
{

}
