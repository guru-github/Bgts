using System.Collections.Generic;
using Abp.Timing;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;
using Bgts.Gps.Migrations.Seed;
using Bgts.Gps.Scheduling.Jobs;

namespace Bgts.Gps.Migrations.Seed.Scheduling
{
    public class DefaultJobMasterCreator : DefaultBaseCreator<JobMaster>
    {
        public DefaultJobMasterCreator(AuthDbContext authContext, VhasDbContext context)
            : base(authContext, context)
        {
        }

        public void Create()
        {
            var cmpEmp = GetCompanyEmployee();
            var clnEmp = GetClientEmployee();

            var list = new List<JobMaster>
            {
                new JobMaster
                {
                    ScheduleId = GetSchedule(DefaultCfg.DefaultScheduleComment1).Id,
                    CompanyEmployeeId = cmpEmp.Id,
                    CompanyEmployeeFirstName = cmpEmp.FirstName,
                    CompanyEmployeeLastName = cmpEmp.LastName,

                    ClientEmployeeId = clnEmp.Id,
                    ClientEmployeeFirstName = clnEmp.FirstName,
                    ClientEmployeeLastName = clnEmp.LastName,

                    JobStatus = (int)JobStatusTypes.Unassigned,
                    AssignedJobTime = Clock.Now.AddDays(-1),
                    JobComments = "Job Comments for test"
                },
                new JobMaster
                {
                    ScheduleId = GetSchedule(DefaultCfg.DefaultScheduleComment2).Id,
                    CompanyEmployeeId = cmpEmp.Id,
                    CompanyEmployeeFirstName = cmpEmp.FirstName,
                    CompanyEmployeeLastName = cmpEmp.LastName,

                    ClientEmployeeId = clnEmp.Id,
                    ClientEmployeeFirstName = clnEmp.FirstName,
                    ClientEmployeeLastName = clnEmp.LastName,

                    JobStatus = (int)JobStatusTypes.Unassigned,
                    AssignedJobTime = Clock.Now.AddDays(-1)
                },
                new JobMaster
                {
                    ScheduleId = GetSchedule(DefaultCfg.DefaultScheduleComment3).Id,
                    CompanyEmployeeId = cmpEmp.Id,
                    CompanyEmployeeFirstName = cmpEmp.FirstName,
                    CompanyEmployeeLastName = cmpEmp.LastName,

                    ClientEmployeeId = clnEmp.Id,
                    ClientEmployeeFirstName = clnEmp.FirstName,
                    ClientEmployeeLastName = clnEmp.LastName,

                    JobStatus = (int)JobStatusTypes.Unassigned,
                    AssignedJobTime = Clock.Now.AddDays(-1)
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(JobMaster item)
        {
            Insert(item);
            VisitContext.SaveChanges();
        } 
    }
}
