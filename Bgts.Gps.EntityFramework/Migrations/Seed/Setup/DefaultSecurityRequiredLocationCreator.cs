using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.SecurityRequiredLocations;
using Bgts.Gps.EntityFramework;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultSecurityRequiredLocationCreator : DefaultBaseCreator<SecurityRequiredLocation>
    {
        private readonly List<SecurityRequiredLocation> locations;
        public DefaultSecurityRequiredLocationCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
            locations = new List<SecurityRequiredLocation>
            {
                new SecurityRequiredLocation
                {
                    City = "ShenZhen",
                    State = "GuangDong",
                    TenantId = TenantId,
                    Zipcode = DefaultCfg.DefaultUnsafeAreaZipcode,
                    CensusTract = "CT1"
                },
                new SecurityRequiredLocation
                {
                    City = "GuangZhou",
                    State = "GuangDong",
                    TenantId = TenantId,
                    Zipcode = "510001",
                    CensusTract = "CT2"
                }
            };
        }

        public void Create()
        {
            CreateUnsafeAreaZipcode();
        }

        private void CreateUnsafeAreaZipcode()
        {
            foreach (var location in locations)
            {
                AddIfNotExists(location);
            }
        }

        private void AddIfNotExists(SecurityRequiredLocation location)
        {
            if (VisitContext.SecurityRequiredLocations.Any(x => x.TenantId == location.TenantId &&
                x.Zipcode == location.Zipcode))
            {
                return;
            }

            VisitContext.SecurityRequiredLocations.Add(location);
            VisitContext.SaveChanges();
        }
    }
}