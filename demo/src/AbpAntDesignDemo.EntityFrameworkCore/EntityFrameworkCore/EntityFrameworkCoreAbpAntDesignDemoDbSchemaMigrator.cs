using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpAntDesignDemo.Data;
using Volo.Abp.DependencyInjection;

namespace AbpAntDesignDemo.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpAntDesignDemoDbSchemaMigrator
        : IAbpAntDesignDemoDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpAntDesignDemoDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpAntDesignDemoDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpAntDesignDemoDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
