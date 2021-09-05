using System.Threading.Tasks;

namespace AbpAntDesignDemo.Data
{
    public interface IAbpAntDesignDemoDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
