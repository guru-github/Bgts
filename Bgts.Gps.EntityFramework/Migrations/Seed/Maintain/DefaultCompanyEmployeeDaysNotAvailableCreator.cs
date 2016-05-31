using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.CompanyEmployees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeeDaysNotAvailableCreator : DefaultBaseCreator<CompanyEmployeeDaysNotAvailable>
    {
        public DefaultCompanyEmployeeDaysNotAvailableCreator(AuthDbContext authContext,
           VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeeDaysNotAvailable>
            {
                new CompanyEmployeeDaysNotAvailable
                {
                    CompanyEmployeeId=GetCompanyEmployee().Id,
                DayOfWeek=5,
                StartTime=DateTime.Parse("2016-07-01 02:00"),
                EndTime=DateTime.Parse("2016-09-01 00:00"),
                OnCall=true,
                ShortDay="SD0"

                },new CompanyEmployeeDaysNotAvailable
                {
                   CompanyEmployeeId=GetCompanyEmployee().Id,
                DayOfWeek=6,
                StartTime=DateTime.Parse("2016-09-01 02:00"),
                EndTime=DateTime.Parse("2016-11-01 00:00"),
                OnCall=true,
                ShortDay="SD1"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeeDaysNotAvailable item)
        {
            if (Table.Any(x => x.CompanyEmployeeId == item.CompanyEmployeeId && x.StartTime == item.StartTime))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
