using System.Data.Common;
using Abp.Zero.EntityFramework;
using Bcs.Gps.Authorization.Roles;
using Bcs.Gps.MultiTenancy;
using Bcs.Gps.Users;

namespace Bcs.Gps.EntityFramework
{
    public class GpsDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public GpsDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in GpsDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of GpsDbContext since ABP automatically handles it.
         */
        public GpsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public GpsDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
