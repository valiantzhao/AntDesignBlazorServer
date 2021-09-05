using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace AbpAntDesignBlazorServer.Bundling
{
    public class BlazorBasicThemeStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_content/AbpAntDesignBlazorServer/libs/abp/css/theme.css");
            context.Files.AddIfNotContains("/_content/AbpAntDesignBlazorServer/libs/tf/css/compatible.css");
            context.Files.AddIfNotContains("/_content/AntDesign/css/ant-design-blazor.css");
            context.Files.AddIfNotContains("/_content/AntDesign.ProLayout/css/ant-design-pro-layout-blazor.css");
        }
    }
}