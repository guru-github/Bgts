using System.Reflection;
using Abp;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Bgts.Auth.Configuration;

namespace Bgts.Auth
{
    /// <summary>
    /// Entity framework module of the application.
    /// </summary>
    //[DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(AuthCoreModule))]
    public class AuthDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            //if (!DebugHelper.IsDebug)
            //{
                IocManager.Register<IAuthDataModuleConfiguration, AuthDataModuleConfiguration>();
            //}
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
