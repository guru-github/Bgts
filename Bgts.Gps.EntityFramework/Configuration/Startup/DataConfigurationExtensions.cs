using Abp.Configuration.Startup;

namespace Bgts.Gps.Configuration.Startup
{
    public static class BgtsDataConfigurationExtensions
    {
        public static IBgtsDataModuleConfiguration BgtsDataModule(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.GetOrCreate("Modules.Bgts.Gps", () => configurations.AbpConfiguration.IocManager.Resolve<IBgtsDataModuleConfiguration>());
        }
    }
}
