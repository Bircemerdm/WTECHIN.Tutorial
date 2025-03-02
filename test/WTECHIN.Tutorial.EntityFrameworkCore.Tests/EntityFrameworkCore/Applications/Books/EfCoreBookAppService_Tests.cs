using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTECHIN.Tutorial.Books;
using Xunit;

namespace WTECHIN.Tutorial.EntityFrameworkCore.Applications.Books
{
    [Collection(TutorialTestConsts.CollectionDefinitionName)]
    public class EfCoreBookAppService_Tests : BookAppService_Tests<TutorialEntityFrameworkCoreTestModule>
    {
    }
}
