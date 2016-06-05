using System.Reflection;
using Abp.Modules;

namespace Abp.EntityFramework
{
    public class AbpEntityFrameworkExModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
