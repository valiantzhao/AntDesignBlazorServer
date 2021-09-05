using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpAntDesignDemo.Data
{
    /* This is used if database provider does't define
     * IAbpAntDesignDemoDbSchemaMigrator implementation.
     */
    public class NullAbpAntDesignDemoDbSchemaMigrator : IAbpAntDesignDemoDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}