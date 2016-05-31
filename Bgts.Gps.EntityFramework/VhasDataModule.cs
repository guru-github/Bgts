using System.Reflection;
using Abp;
using Abp.EntityFramework;
using Abp.Modules;
using Bgts.Gps.Configuration;

namespace Bgts.Gps
{
    /// <summary>
    /// Entity framework module of the application.
    /// </summary>
    [DependsOn(typeof(VhasCoreModule), typeof(AbpEntityFrameworkModule))]
    public class VhasDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            //web.config (or app.config for non-web projects) file should containt a connection string named "Default".
            if (!DebugHelper.IsDebug)
            {
                //Configuration.DefaultNameOrConnectionString = "BcsVhas";
                IocManager.Register<IVhasDataModuleConfiguration, VhasDataModuleConfiguration>();
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
