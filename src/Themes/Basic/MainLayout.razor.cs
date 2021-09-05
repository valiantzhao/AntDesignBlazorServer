using System;
using System.Net.Http;
using System.Threading.Tasks;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Volo.Abp.Localization;
using Volo.Abp.UI.Navigation;

namespace AbpAntDesignBlazorServer
{
    public partial class MainLayout : IDisposable
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] protected IMenuManager MenuManager { get; set; }
        [Inject] protected HttpClient HttpClient { get; set; }
        [Inject] public ILogger<MainLayout> Logger { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }
        [Inject] ILanguageProvider LanguageProvider { get; set; }
        [Parameter] public RenderFragment FooterRender { get; set; }

        private MenuDataItem[] _menuData = { };
        private bool IsCollapseShown { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += OnLocationChanged;
        }
        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("start to ini layout async");
            await base.OnInitializedAsync();
            await IniMainMenu();
        }

        private async Task IniMainMenu()
        {
            ApplicationMenu menu = await MenuManager.GetAsync(StandardMenus.Main);

            if (menu != null)
            {
                _menuData = GetMenuDataItems(menu.Items);
            }
        }
        private MenuDataItem[] GetMenuDataItems(ApplicationMenuItemList menuItems)
        {
            if (menuItems != null && menuItems.Count > 0)
            {
                MenuDataItem[] antMenuItems;
                antMenuItems = new MenuDataItem[menuItems.Count];
                for (int i = 0; i < antMenuItems.Length; i++)
                {
                    MenuDataItem item = new MenuDataItem();
                    var url = menuItems[i].Url == null ? "#" : menuItems[i].Url.TrimStart('/', '~');
                    item.Path = url;
                    item.Name = menuItems[i].DisplayName;
                    item.Key = menuItems[i].Name;
                    item.Icon = menuItems[i].Icon;
                    antMenuItems[i] = item;

                    if (menuItems[i].Items != null && menuItems[i].Items.Count > 0)
                    {
                        antMenuItems[i].Children = GetMenuDataItems(menuItems[i].Items);
                    }
                }
                return antMenuItems;
            }
            return null;
        }

        private void ToggleCollapse()
        {
            IsCollapseShown = !IsCollapseShown;
        }

        public void Dispose()
        {
            //NavigationManager.LocationChanged -= OnLocationChanged;
        }
        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            IsCollapseShown = false;
            InvokeAsync(StateHasChanged);
        }
    }
}
