using System.Data.Entity.Migrations;
using Abp;
using Abp.Dependency;
using Bgts.Auth.Configuration;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Migrations.Seed;

namespace Bgts.Gps.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VhasDbContext>
    {
        public Configuration()
        {
            if (DebugHelper.IsDebug)
            {
                AutomaticMigrationsEnabled = false;
                //AutomaticMigrationDataLossAllowed = true;
            }
            else
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
            }

            ContextKey = "Vhas";
        }

        protected override void Seed(VhasDbContext context)
        {
            var ioc = IocManager.Instance;
            if (ioc.IsRegistered<IAuthDataModuleConfiguration>())
            {
                using (var config = ioc.ResolveAsDisposable<IAuthDataModuleConfiguration>())
                {
                    using (var authContext = new AuthDbContext(config.Object))
                    {
                        new VhasDbInit(authContext, context).Create();
                    }
                }
            }
            else
            {
                using (var authContext = new AuthDbContext("BcsAuth"))
                {
                    new VhasDbInit(authContext, context).Create();
                }
            }
        }
    }

}
