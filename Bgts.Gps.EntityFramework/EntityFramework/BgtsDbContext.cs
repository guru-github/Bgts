using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Abp;
using Abp.EntityFramework;
using Bgts.Gps.Core.Company;
using Bgts.Gps.Core.Application;
using Bgts.Gps.Core.Employee;
using Bgts.Gps.Core.Event;
using Bgts.Gps.Core.GpsTrack;
using Bgts.Gps.Core.MobileDevice;
using Bgts.Gps.Configuration;

namespace Bgts.Gps.EntityFramework
{
    public class VhasDbContext : AbpDbContext
    {
        /// <summary>
        /// Used to get current session values.
        /// </summary>
        //public IVhasSession VhasSession { get; set; }

        //#region Setup
        //public virtual IDbSet<Company> Companies { get; set; }
        //public virtual IDbSet<CompanyBranch> CompanyBranchs { get; set; }
        //public virtual IDbSet<Area> Areas { get; set; }
        //public virtual IDbSet<City> Cities { get; set; }
        //public virtual IDbSet<CompanyContact> CompanyContacts { get; set; }
        //public virtual IDbSet<Skill> Skills { get; set; }
        //public virtual IDbSet<Timezone> Timezones { get; set; }
        //public virtual IDbSet<SecurityRequiredLocation> SecurityRequiredLocations { get; set; }
        //public virtual IDbSet<CompanyBranchUser> CompanyBranchUsers { get; set; }
        //public virtual IDbSet<Patient> Patients { get; set; }
        //#endregion

        //#region Maintain
        //public virtual IDbSet<Client> Clients { get; set; }
        //public virtual IDbSet<ClientBranch> ClientBranchs { get; set; }
        //public virtual IDbSet<ClientContact> ClientContacts { get; set; }
        //public virtual IDbSet<ClientEmployee> ClientEmployees { get; set; }
        //public virtual IDbSet<ClientEmployeePicture> ClientEmployeePictures { get; set; }

        //public virtual IDbSet<CompanyEmployeeAbsence> CompanyEmployeeAbsences { get; set; }
        //public virtual IDbSet<CompanyEmployeeBan> CompanyEmployeeBans { get; set; }
        //public virtual IDbSet<CompanyEmployeeDaysNotAvailable> CompanyEmployeeDaysNotAvailables { get; set; }
        //public virtual IDbSet<CompanyEmployeeEmail> CompanyEmployeeEmails { get; set; }
        //public virtual IDbSet<CompanyEmployeePicture> CompanyEmployeePictures { get; set; }
        //public virtual IDbSet<CompanyEmployee> CompanyEmployees { get; set; }
        //public virtual IDbSet<CompanyEmployeeSkill> CompanyEmployeeSkills { get; set; }
        //public virtual IDbSet<CompanyEmployeeTelephone> CompanyEmployeeTelephones { get; set; }
        //public virtual IDbSet<CompanyEmployeeType> CompanyEmployeeTypes { get; set; }
        //public virtual IDbSet<CompanyEmployeeWorkAtCity> CompanyEmployeeWorkAtCities { get; set; }
        //public virtual IDbSet<InactiveReason> InactiveReasons { get; set; }
        //public virtual IDbSet<IncidentLogHistory> IncidentLogHistories { get; set; }
        //public virtual IDbSet<IncidentLog> IncidentLogs { get; set; }
        //#endregion

        //public virtual IDbSet<ActiveCode> ActiveCodes { get; set; }

        //#region Scheduling
        //public virtual IDbSet<Schedule> Schedules { get; set; }
        //public virtual IDbSet<JobMaster> ScheduleLogs { get; set; }
        //public virtual IDbSet<JobDetail> JobDetails { get; set; }
        //public virtual IDbSet<JobAccounting> JobAccountings { get; set; }
        //#endregion

        //static VhasDbContext()
        //{
        //    if (!DebugHelper.IsDebug)
        //    {
        //        //Database.SetInitializer(new CreateDatabaseIfNotExists<VhasDbContext>());
        //        Database.SetInitializer(new MigrateDatabaseToLatestVersion<VhasDbContext, Migrations.Configuration>());
        //    }
        //}

        /* Setting "Default" to base class helps us when working migration commands on Package Manager Console.
        * But it may cause problems when working Migrate.exe of EF. ABP works either way.         * 
        */
        public VhasDbContext()
            : base("BcsVhas")
        {
            //Update-Database -ConnectionString "Server=CARL\MSSQL2012; Database=BcsVhas; Trusted_Connection=Yes;" -ConnectionProviderName "System.Data.SqlClient" -Verbose -ProjectName "Bgts.Gps.EntityFramework"
        }

        /* This constructor is used by ABP to pass connection string defined in AbpZeroTemplateDataModule.PreInitialize.
         * Notice that, actually you will not directly create an instance of AbpZeroTemplateDbContext since ABP automatically handles it.
         */
        public VhasDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public VhasDbContext(BgtsDataModuleConfiguration configuration)
#if DEBUG
            : base(configuration.Connection, true)
#else
            : base(configuration.NameOrConnectionString)
#endif
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection.
         */
        public VhasDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !string.IsNullOrEmpty(type.Namespace) && type.FullName.StartsWith("Bgts.Gps.Mapping"))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic) configurationInstance);
            }

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        /*
        public override void Initialize()
        {
            base.Initialize();
            this.SetFilterScopedParameterValue(MedVisitDataFilters.MayHaveBranch,
                MedVisitDataFilters.Parameters.BranchId, VhasSession.BranchId);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Filter(MedVisitDataFilters.MayHaveBranch,
                (IMayHaveBranch entity, Guid? branchId) => entity.BranchId == branchId, (Guid?)null);
        }
        */
    }
}
