using System.Data.Common;
using System.Data.Entity;
using Abp;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.BackgroundJobs;
using Abp.Configuration;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Notifications;
using Abp.Organizations;
using Abp.Zero.EntityFramework;
//using Bgts.Auth.Authorization.Roles;
//using Bgts.Auth.Authorization.Users;
//using Bgts.Auth.Configuration;
//using Bgts.Auth.MultiTenancy;
//using Bgts.Auth.Storage;

namespace Bgts.Auth.EntityFramework
{
    public class AuthDbContext //: AbpZeroDbContext<Company, Role, User>
    {
        //Update-Database -ConnectionString "Server=CARL\MSSQL2012; Database=Bcs_Auth; Trusted_Connection=Yes;" -ConnectionProviderName "System.Data.SqlClient" -Verbose -ProjectName "Bgts.Auth.EntityFramework"
        static AuthDbContext()
        {
            //if (!DebugHelper.IsDebug)
            //{
            //    //Database.SetInitializer(new CreateDatabaseIfNotExists<AuthDbContext>());
            //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthDbContext, Migrations.Configuration>());
            //}
        }
      
        /* Define an IDbSet for each entity of the application */

        //public IDbSet<BinaryObject> BinaryObjects { get; set; }

        ///* Setting "Default" to base class helps us when working migration commands on Package Manager Console.
        // * But it may cause problems when working Migrate.exe of EF. ABP works either way.         * 
        // */
        //public AuthDbContext()
        //    : base("BcsAuth")
        //{

        //}

        /* This constructor is used by ABP to pass connection string defined in AbpZeroTemplateDataModule.PreInitialize.
         * Notice that, actually you will not directly create an instance of AuthDbContext since ABP automatically handles it.
         */
        //public AuthDbContext(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{

        //}
        
//        public AuthDbContext(IAuthDataModuleConfiguration configuration)
//#if DEBUG
//            : base(configuration.Connection, true)
//#else
//            : base(configuration.NameOrConnectionString)
//#endif
//        {

//        }

//        /* This constructor is used in tests to pass a fake/mock connection.
//         */
//        public AuthDbContext(DbConnection dbConnection)
//            : base(dbConnection, true)
//        {

//        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Tenant>().ToTable("BCS_Tenants");
//            modelBuilder.Entity<Role>().ToTable("BCS_Roles");
//            modelBuilder.Entity<User>().ToTable("BCS_Users");
//            modelBuilder.Entity<UserLogin>().ToTable("BCS_UserLogins");
//            modelBuilder.Entity<UserRole>().ToTable("BCS_UserRoles");

//            modelBuilder.Entity<PermissionSetting>().ToTable("BCS_Permissions");
//            modelBuilder.Entity<RolePermissionSetting>().ToTable("BCS_Permissions");
//            modelBuilder.Entity<UserPermissionSetting>().ToTable("BCS_Permissions");


//            modelBuilder.Entity<Setting>().ToTable("BCS_Settings");
//            modelBuilder.Entity<AuditLog>().ToTable("BCS_AuditLogs");
//            modelBuilder.Entity<Edition>().ToTable("BCS_Editions");

//            modelBuilder.Entity<FeatureSetting>().ToTable("BCS_Features");
//            modelBuilder.Entity<TenantFeatureSetting>().ToTable("BCS_Features");
//            modelBuilder.Entity<EditionFeatureSetting>().ToTable("BCS_Features");

//            modelBuilder.Entity<ApplicationLanguage>().ToTable("BCS_Languages");
//            modelBuilder.Entity<ApplicationLanguageText>().ToTable("BCS_LanguageTexts");

//            modelBuilder.Entity<OrganizationUnit>().ToTable("BCS_OrganizationUnits");
//            modelBuilder.Entity<UserOrganizationUnit>().ToTable("BCS_UserOrganizationUnits");

//            modelBuilder.Entity<BackgroundJobInfo>().ToTable("BCS_BackgroundJobs");
//            modelBuilder.Entity<NotificationInfo>().ToTable("BCS_Notifications");
//            modelBuilder.Entity<NotificationSubscriptionInfo>().ToTable("BCS_NotificationSubscriptions");
//            modelBuilder.Entity<UserNotificationInfo>().ToTable("BCS_UserNotifications");

//            modelBuilder.Entity<UserLoginAttempt>().ToTable("BCS_UserLoginAttempts");
//            //modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("BCS_");

//            base.OnModelCreating(modelBuilder);
//        }
    }
}
