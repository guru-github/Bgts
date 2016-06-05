using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Bcs.Gps.EntityFramework;

namespace Bcs.Gps.Migrator
{
    [DependsOn(typeof(GpsDataModule))]
    public class GpsMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<GpsDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}