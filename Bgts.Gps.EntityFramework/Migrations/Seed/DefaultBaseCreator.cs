using System;
using System.Data.Entity;
using System.Linq;
using Bgts.Auth.Authorization.Users;
using Bgts.Auth.EntityFramework;
using Bgts.Auth.MultiTenancy;
using Bgts.Gps.Setup.Areas;
using Bgts.Gps.Setup.Cities;
using Bgts.Gps.Setup.Companies;
using Bgts.Gps.Setup.CompanyBranchs;
using Bgts.Gps.Setup.Timezones;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.ClientBranchs;
using Bgts.Gps.Maintain.ClientEmployees;
using Bgts.Gps.Maintain.Clients;
using Bgts.Gps.Maintain.CompanyEmployees;
using Bgts.Gps.Setup.Skills;
using Bgts.Gps.Scheduling.Schedules;
using Bgts.Gps.Scheduling.Jobs;

namespace Bgts.Gps.Migrations.Seed
{
    public class DefaultBaseCreator<TEntity>  where TEntity : class
    {
        protected VhasDbContext VisitContext
        {
            get;
            private set;
        }

        protected AuthDbContext AuthContext
        {
            get;
            private set;
        }

        protected int? TenantId { get; set; }

        protected long? UserId { get; set; }

        protected Tenant Tenant { get; set; }

        protected User User { get; set; }

        private void InitTenant()
        {
            Tenant = AuthContext.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            TenantId = Tenant == null ? (int?)null : Tenant.Id;
        }

        private void InitUser()
        {
            User = AuthContext.Users.FirstOrDefault(t => t.UserName == User.AdminUserName && t.TenantId == TenantId);
            UserId = User == null ? (long?)null : User.Id;
        }

        public DefaultBaseCreator(
            AuthDbContext authContext,
            VhasDbContext context
            )
        {
            AuthContext = authContext;
            VisitContext = context;

            InitTenant();
            InitUser();
        }

        protected void IsNullAndThrowException<T>(T t) where T : class
        {
            if (t == null)
            {
                throw new Exception("Please init data for type : " + typeof(T).Name);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }

        public virtual DbSet<TEntity> Table
        {
            get
            {
                return VisitContext.Set<TEntity>();
            }
        }

        public TEntity Insert(TEntity entity)
        {
            var model = Table.Add(entity);
            return model;
        }

        protected CompanyBranch GetCompanyBranch(string branchName = DefaultCfg.CompanyBranch_B1)
        {
            var branch = VisitContext.CompanyBranchs.FirstOrDefault(x => x.BranchName == branchName);
            IsNullAndThrowException(branch);

            return branch;
        }

        protected Timezone GetTimezone(string timezoneCode = DefaultCfg.DefaultTimezoneCode)
        {
            var timezone = VisitContext.Timezones.FirstOrDefault(x => x.TimezoneCode == timezoneCode);
            IsNullAndThrowException(timezone);

            return timezone;
        }

        protected Company GetCompany(string companyName = DefaultCfg.DefaultCompanyName)
        {
            var company = VisitContext.Companies.FirstOrDefault(x => x.CompanyName == companyName);
            IsNullAndThrowException(company);

            return company;
        }

        protected City GetCity(string cityName = DefaultCfg.DefaultCityName)
        {
            var city = VisitContext.Cities.FirstOrDefault(x => x.CityName == cityName);
            IsNullAndThrowException(city);

            return city;
        }

        protected Area GetArea(string areaName = DefaultCfg.DefaultAreaName)
        {
            var area = VisitContext.Areas.FirstOrDefault(x => x.Description == areaName);
            IsNullAndThrowException(area);

            return area;
        }

        protected Client GetClient(string clientName = DefaultCfg.DefaultClientName)
        {
            var client = VisitContext.Clients.FirstOrDefault(x => x.Name == clientName);
            IsNullAndThrowException(client);

            return client;
        }

        protected ClientBranch GetClientBranch(string branchName = DefaultCfg.ClientBranch_B1)
        {
            var branch = VisitContext.ClientBranchs.FirstOrDefault(x => x.BranchName == branchName);
            IsNullAndThrowException(branch);

            return branch;
        }

        protected CompanyEmployee GetCompanyEmployee(string phoneNo = DefaultCfg.DefaultCompanyEmployeePhoneNo)
        {
            var cmpEmp = VisitContext.CompanyEmployees.FirstOrDefault(x => x.PhoneNo == phoneNo);
            IsNullAndThrowException(cmpEmp);

            return cmpEmp;
        }

        protected ClientEmployee GetClientEmployee(string phoneNo = DefaultCfg.DefaultClientEmployeePhoneNo)
        {
            var clnEmp = VisitContext.ClientEmployees.FirstOrDefault(x => x.PhoneNo == phoneNo);
            IsNullAndThrowException(clnEmp);

            return clnEmp;
        }

        protected Skill GetSkill(string skill = DefaultCfg.DefaultSkill)
        {
            var entity = VisitContext.Skills.FirstOrDefault(x => x.Description == skill);
            IsNullAndThrowException(entity);
            return entity;
        }

        public Schedule GetSchedule(string comment)
        {
            var schedule = VisitContext.Schedules.FirstOrDefault(x => x.Comments == comment);
            return schedule;
        }

        public JobMaster GetJobMaster(string comment = DefaultCfg.DefaultJobMasterComment)
        {
            var jobMaster = VisitContext.ScheduleLogs.FirstOrDefault(x => x.JobComments == comment);
            return jobMaster;
        }


    }
}
