using Volo.Abp.Modularity;

namespace AbpAntDesignDemo
{
    [DependsOn(
        typeof(AbpAntDesignDemoApplicationModule),
        typeof(AbpAntDesignDemoDomainTestModule)
        )]
    public class AbpAntDesignDemoApplicationTestModule : AbpModule
    {

    }
}