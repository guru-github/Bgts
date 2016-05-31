using System.Collections.Generic;
using System.Linq;
using Abp.Timing;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;
using Bgts.Gps.Migrations.Seed;
using Bgts.Gps.Scheduling.Schedules;

namespace Bgts.Gps.Migrations.Seed.Scheduling
{
    public class DefaultScheduleCreator : DefaultBaseCreator<Schedule>
    {
        public DefaultScheduleCreator(AuthDbContext authContext, VhasDbContext context) 
            : base(authContext, context)
        {
        }

        public void Create()
        {
            var clientBranch = GetClientBranch(DefaultCfg.ClientBranch_B11);
            var companyBranch = GetCompanyBranch(DefaultCfg.CompanyBranch_B11);

            var list = new List<Schedule>
            {
                new Schedule
                {
                    TenantId = TenantId,
                    ClientId = clientBranch.ClientId,
                    ClientBranchId = clientBranch.Id,
                    CompanyId = companyBranch.CompanyId ?? 0,
                    CompanyBranchId = companyBranch.Id,
                    Department = (int)DepartmentTypes.MinistryOfPersonnel,
                    ScheduleStatus = (int)ScheduleStatusTypes.Open,
                    ScheduleStartTime = Clock.Now.AddDays(-1),
                    DayOfSchedule = (int)Clock.Now.AddDays(-1).DayOfWeek,
                    ShortDay = Clock.Now.AddDays(-1).DayOfWeek.ToString().Substring(0, 3),
                    Comments = "Patient : Sunny Li",
                    
                },
                new Schedule
                {
                    TenantId = TenantId,
                    ClientId = clientBranch.ClientId,
                    ClientBranchId = clientBranch.Id,
                    CompanyId = companyBranch.CompanyId ?? 0,
                    CompanyBranchId = companyBranch.Id,
                    Department = (int)DepartmentTypes.MinistryOfPersonnel,
                    ScheduleStatus = (int)ScheduleStatusTypes.Open,
                    ScheduleStartTime = Clock.Now.AddDays(-1),
                    DayOfSchedule = (int)Clock.Now.AddDays(-1).DayOfWeek,
                    ShortDay = Clock.Now.AddDays(-1).DayOfWeek.ToString().Substring(0, 3),
                    Comments = "Patient : Joe Zhu"
                },
                new Schedule
                {
                    TenantId = TenantId,
                    ClientId = clientBranch.ClientId,
                    ClientBranchId = clientBranch.Id,
                    CompanyId = companyBranch.CompanyId ?? 0,
                    CompanyBranchId = companyBranch.Id,
                    Department = (int)DepartmentTypes.MinistryOfPersonnel,
                    ScheduleStatus = (int)ScheduleStatusTypes.Open,
                    ScheduleStartTime = Clock.Now.AddDays(-1),
                    DayOfSchedule = (int)Clock.Now.AddDays(-1).DayOfWeek,
                    ShortDay = Clock.Now.AddDays(-1).DayOfWeek.ToString().Substring(0, 3),
                    Comments = "Patient : Frank Wen"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(Schedule item)
        {
            if (Table.Any(x => x.Comments == item.Comments && x.TenantId == TenantId))
            {
                return;
            }
            Insert(item);
           
            VisitContext.SaveChanges();
        } 
    }
}
