using Abp.Configuration.Startup;

namespace Bgts.Gps.Configuration.Startup
{
    public static class VhasDataConfigurationExtensions
    {
        public static IVhasDataModuleConfiguration VhasDataModule(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.GetOrCreate("Modules.Bgts.Gps", () => configurations.AbpConfiguration.IocManager.Resolve<IVhasDataModuleConfiguration>());
        }
    }
}
