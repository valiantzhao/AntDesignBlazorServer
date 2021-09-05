using AbpAntDesignDemo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpAntDesignDemo.Blazor
{
    public abstract class AbpAntDesignDemoComponentBase : AbpComponentBase
    {
        protected AbpAntDesignDemoComponentBase()
        {
            LocalizationResource = typeof(AbpAntDesignDemoResource);
        }
    }
}
