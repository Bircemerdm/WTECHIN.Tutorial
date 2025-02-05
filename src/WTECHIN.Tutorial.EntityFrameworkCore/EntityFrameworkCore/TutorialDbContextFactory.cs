using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WTECHIN.Tutorial.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class TutorialDbContextFactory : IDesignTimeDbContextFactory<TutorialDbContext>
{
    public TutorialDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        TutorialEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<TutorialDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new TutorialDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WTECHIN.Tutorial.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
