using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace WTECHIN.Tutorial.Pages;

[Collection(TutorialTestConsts.CollectionDefinitionName)]
public class Index_Tests : TutorialWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
