using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpAntDesignDemo.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class AbpAntDesignDemoDbContextFactory : IDesignTimeDbContextFactory<AbpAntDesignDemoDbContext>
    {
        public AbpAntDesignDemoDbContext CreateDbContext(string[] args)
        {
            AbpAntDesignDemoEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpAntDesignDemoDbContext>()
                .UseSqlite(configuration.GetConnectionString("Default"));

            return new AbpAntDesignDemoDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpAntDesignDemo.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
