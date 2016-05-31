using Abp;
using Bgts.Auth.EntityFramework;
using Bgts.Auth.Migrations.Seed;

namespace Bgts.Auth.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthDbContext>
    {
        public Configuration()
        {
            ContextKey = "Bgts.Auth.Migrations.Configuration";
            if (DebugHelper.IsDebug)
            {
                AutomaticMigrationsEnabled = false;
            }
            else
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
            }
        }

        protected override void Seed(AuthDbContext context)
        {
            new InitialDbBuilder(context).Create();
        }
    }
}
