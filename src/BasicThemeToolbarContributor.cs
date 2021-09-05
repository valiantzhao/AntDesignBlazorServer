using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace AbpAntDesignBlazorServer
{
    public class BasicThemeToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
                //context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
                //context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            }
            return Task.CompletedTask;
        }
    }
}
