using System.Threading.Tasks;
using AbpAntDesignDemo.Localization;
using AbpAntDesignDemo.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace AbpAntDesignDemo.Blazor.Menus
{
    public class AbpAntDesignDemoMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<AbpAntDesignDemoResource>();
            context.Menu.Items.Insert(0, new ApplicationMenuItem(AbpAntDesignDemoMenus.Home, l["Menu:Home"], "/", icon: "home", order: 0));
             #region 系统管理
            var adminmenu = context.Menu.GetAdministration();
            adminmenu.TryRemoveMenuItem(IdentityMenuNames.GroupName);
            adminmenu.Order = 2000;
            adminmenu.Icon = "setting";
            adminmenu.DisplayName = "系统设置";
            //adminmenu.RequiredPermissionName = CarsPermissions.SystemMange.Default;
            adminmenu.AddItem(new ApplicationMenuItem(IdentityMenuNames.Roles, "角色管理", url: "~/Identity/Roles", icon: "user-switch"));
            adminmenu.AddItem(new ApplicationMenuItem(IdentityMenuNames.Users, "用户管理", url: "~/Identity/Users", icon: "user"));
            adminmenu.AddItem(new ApplicationMenuItem("AbpAntDesignDemo.author", l["图书"], url: "/book", icon: "setting"));
            adminmenu.AddItem(new ApplicationMenuItem("AbpAntDesignDemo.book", "作者", url: "~/authors", icon: "user"));
            #endregion
            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

            return Task.CompletedTask;
        }
    }
}
