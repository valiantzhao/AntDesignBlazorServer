using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpAntDesignDemo.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class AbpAntDesignDemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpAntDesignDemo";
    }
}
