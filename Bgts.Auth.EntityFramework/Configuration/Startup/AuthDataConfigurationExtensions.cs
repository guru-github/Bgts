using Abp.Configuration.Startup;

namespace Bgts.Auth.Configuration.Startup
{
    public static class AuthDataConfigurationExtensions
    {
        public static IAuthDataModuleConfiguration BcsAuthDataModule(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.GetOrCreate("Modules.Bgts.Auth", () => configurations.AbpConfiguration.IocManager.Resolve<IAuthDataModuleConfiguration>());
        }
    }
}
