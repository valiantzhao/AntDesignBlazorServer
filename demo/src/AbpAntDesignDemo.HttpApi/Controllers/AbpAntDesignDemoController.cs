using AbpAntDesignDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpAntDesignDemo.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpAntDesignDemoController : AbpController
    {
        protected AbpAntDesignDemoController()
        {
            LocalizationResource = typeof(AbpAntDesignDemoResource);
        }
    }
}