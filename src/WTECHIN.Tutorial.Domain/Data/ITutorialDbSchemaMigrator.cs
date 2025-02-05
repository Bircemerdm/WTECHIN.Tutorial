using System.Threading.Tasks;

namespace WTECHIN.Tutorial.Data;

public interface ITutorialDbSchemaMigrator
{
    Task MigrateAsync();
}
