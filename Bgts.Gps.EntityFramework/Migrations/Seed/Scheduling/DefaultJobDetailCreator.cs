using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Abp;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Migrations.Seed;
using Bgts.Gps.Scheduling.Jobs;

namespace Bgts.Gps.Migrations.Seed.Scheduling
{
    public class DefaultJobDetailCreator: DefaultBaseCreator<JobDetail>
    {
        public DefaultJobDetailCreator(AuthDbContext authContext, VhasDbContext context)
            : base(authContext, context)
        {
        }

        public void Create()
        {
            var jobMasterId = GetJobMaster().Id;
            var companyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B11).Id;

            var patients = this.VisitContext.Patients.Where(x => x.CompanyBranchId == companyBranchId);

            var list = new List<JobDetail>();
            var index = 1;
            foreach (var item in patients)
            {
                list.Add(new JobDetail
                {
                    JobMasterId = jobMasterId,
                    StartTime = DateTime.Now.AddHours(index),
                    EndTime = DateTime.Now.AddHours(index + 1),
                    PatientAddress1 = item.Address,
                    PatientCensusBlockNumber = item.CensusBlockNumber,
                    PatientCensusTract = item.CensusTract,
                    PatientCityId = item.CityId,
                    PatientId = item.Id,
                    PatientZipcode = item.Zipcode,
                    VisitNo = RandomHelper.GetRandom(100000, 999999),
                    VisitComment = index == 1 ? DefaultCfg.DefaultJobDetailComment : "Comment for test " + item.Id + item.CityId
                });
                Thread.Sleep(200);
                index ++;
            }


            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(JobDetail item)
        {
            if (Table.Any(x => x.VisitComment == item.VisitComment))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        } 
    }
}
