using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WTECHIN.Tutorial.Data;
using Volo.Abp.DependencyInjection;

namespace WTECHIN.Tutorial.EntityFrameworkCore;

public class EntityFrameworkCoreTutorialDbSchemaMigrator
    : ITutorialDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTutorialDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the TutorialDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TutorialDbContext>()
            .Database
            .MigrateAsync();
    }
}
