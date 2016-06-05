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
    //[DependsOn(typeof(BgtsCoreModule), typeof(AbpEntityFrameworkModule))]
    public class BgtsDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            //web.config (or app.config for non-web projects) file should containt a connection string named "Default".
            //if (!DebugHelper.IsDebug)
            //{
                //Configuration.DefaultNameOrConnectionString = "BcsBgts";
                IocManager.Register<IBgtsDataModuleConfiguration, BgtsDataModuleConfiguration>();
            //}
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
