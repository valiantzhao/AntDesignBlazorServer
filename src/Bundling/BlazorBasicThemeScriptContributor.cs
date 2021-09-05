using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace AbpAntDesignBlazorServer.Bundling
{
    public class BlazorBasicThemeScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_content/AntDesign/js/ant-design-blazor.js");
        }
    }
}