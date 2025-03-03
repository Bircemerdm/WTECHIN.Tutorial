using WTECHIN.Tutorial.Authors;
using Xunit;

namespace WTECHIN.Tutorial.EntityFrameworkCore.Applications.Authors;


[Collection(TutorialTestConsts.CollectionDefinitionName)]
public class CoreAuthorAppService_Tests:AuthorAppService_Tests<TutorialEntityFrameworkCoreTestModule>
{
    
}