using Volo.Abp.Settings;

namespace AbpAntDesignDemo.Settings
{
    public class AbpAntDesignDemoSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpAntDesignDemoSettings.MySetting1));
        }
    }
}
