using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Bcs.Gps
{
    [DependsOn(typeof(GpsCoreModule), typeof(AbpAutoMapperModule))]
    public class GpsApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
