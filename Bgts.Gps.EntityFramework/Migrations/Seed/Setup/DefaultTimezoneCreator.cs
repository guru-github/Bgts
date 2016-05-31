using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.Timezones;
using Bgts.Gps.EntityFramework;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultTimezoneCreator : DefaultBaseCreator<Timezone>
    {
        private readonly List<Timezone> timeZones;

        public DefaultTimezoneCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
            timeZones = new List<Timezone>
            {
                new Timezone
                {
                    TimezoneCode = DefaultCfg.DefaultTimezoneCode,
                    Description = "Pacific Time",
                    IsNegativeGMT = true,
                    GMTOffsetTime = 8,
                    TenantId = TenantId
                },
                new Timezone
                {
                    TimezoneCode = "ET",
                    Description = "Eastern Time",
                    IsNegativeGMT = true,
                    GMTOffsetTime = 5,
                    TenantId = TenantId
                },
                new Timezone
                {
                    TimezoneCode = "CT",
                    Description = "Central Time",
                    IsNegativeGMT = true,
                    GMTOffsetTime = 6,
                    TenantId = TenantId
                },
                new Timezone
                {
                    TimezoneCode = "MT",
                    Description = "Mountain Time",
                    IsNegativeGMT = true,
                    GMTOffsetTime = 7,
                    TenantId = TenantId
                }
            };
        }

        public void Create()
        {
            CreateTimeZone();
        }

        private void CreateTimeZone()
        {
            foreach (var timezone in timeZones)
            {
                AddIfNotExists(timezone);
            }
        }

        private void AddIfNotExists(Timezone timezone)
        {
            if (VisitContext.Timezones.Any(l => l.TenantId == timezone.TenantId && l.TimezoneCode == timezone.TimezoneCode))
            {
                return;
            }

            VisitContext.Timezones.Add(timezone);
            VisitContext.SaveChanges();
        }
    }
}