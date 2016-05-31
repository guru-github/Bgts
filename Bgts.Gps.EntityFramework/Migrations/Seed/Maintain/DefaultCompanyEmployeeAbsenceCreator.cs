using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.CompanyEmployees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeeAbsenceCreator : DefaultBaseCreator<CompanyEmployeeAbsence>
    {
        public DefaultCompanyEmployeeAbsenceCreator(AuthDbContext authContext,
          VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeeAbsence>
            {
                new CompanyEmployeeAbsence
                {
                      CompanyEmployeeId = GetCompanyEmployee().Id,
                Pending = true,
                StartTime = DateTime.Parse("2016-06-01 00:00"),
                EndTime=DateTime.Parse("2016-06-01 06:00"),
                Comment="TestComment",
                Reason="DemoReason"

                },new CompanyEmployeeAbsence
                {
                      CompanyEmployeeId = GetCompanyEmployee().Id,
                Pending = true,
                StartTime = DateTime.Parse("2016-07-01 02:00"),
                EndTime=DateTime.Parse("2016-08-01 09:00"),
                Comment="TestComment1",
                Reason="DemoReason1"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeeAbsence item)
        {
            if (Table.Any(x => x.CompanyEmployeeId == item.CompanyEmployeeId && x.StartTime==item.StartTime))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
