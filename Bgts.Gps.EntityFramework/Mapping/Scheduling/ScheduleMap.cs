using System.Data.Entity.ModelConfiguration;
using Bgts.Gps.Scheduling.Schedules;
using Abp.EntityFramework.Extensions;

namespace Bgts.Gps.Mapping.Scheduling
{
    class ScheduleMap : EntityTypeConfiguration<Schedule>
    {
        public ScheduleMap()
        {
            this.HasIndex("IX_Schedule_TenantId_ClientBranchId_CompanyBranchId_ScheduleStartTime", 
                    x=> x.Property(m => m.TenantId),
                    x => x.Property(m => m.ClientBranchId),
                    x => x.Property(m => m.CompanyBranchId),
                    x => x.Property(m => m.ScheduleStartTime)
                );
        }
    }
}
