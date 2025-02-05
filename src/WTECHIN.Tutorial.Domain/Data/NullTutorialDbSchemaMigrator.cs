using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WTECHIN.Tutorial.Data;

/* This is used if database provider does't define
 * ITutorialDbSchemaMigrator implementation.
 */
public class NullTutorialDbSchemaMigrator : ITutorialDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
