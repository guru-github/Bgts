using System.Data.Entity.ModelConfiguration;
using Abp.EntityFramework.Extensions;
using Bgts.Gps.Scheduling.Jobs;

namespace Bgts.Gps.Mapping.Scheduling
{
    class JobMasterMap : EntityTypeConfiguration<JobMaster>
    {
        public JobMasterMap()
        {
            this.HasIndex("IX_JobMaster_ScheduleId_CompanyEmpoyeeId_JobStatus",
                    x => x.Property(m => m.ScheduleId),
                    x => x.Property(m => m.CompanyEmployeeId),
                    x => x.Property(m => m.JobStatus)
                );
        }
    }
}
