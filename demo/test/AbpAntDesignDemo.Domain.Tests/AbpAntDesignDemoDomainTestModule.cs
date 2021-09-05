using AbpAntDesignDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpAntDesignDemo
{
    [DependsOn(
        typeof(AbpAntDesignDemoEntityFrameworkCoreTestModule)
        )]
    public class AbpAntDesignDemoDomainTestModule : AbpModule
    {

    }
}