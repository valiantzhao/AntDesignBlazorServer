using System;
using System.Collections.Generic;
using System.Text;
using AbpAntDesignDemo.Localization;
using Volo.Abp.Application.Services;

namespace AbpAntDesignDemo
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpAntDesignDemoAppService : ApplicationService
    {
        protected AbpAntDesignDemoAppService()
        {
            LocalizationResource = typeof(AbpAntDesignDemoResource);
        }
    }
}
