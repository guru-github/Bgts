using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.Areas;
using Bgts.Gps.EntityFramework;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultAreaCreator : DefaultBaseCreator<Area>
    {
        private readonly List<Area> areas;

        public DefaultAreaCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
            areas = new List<Area>
            {
                new Area
                {
                    Description = DefaultCfg.DefaultAreaName,
                    TenantId = TenantId
                },
                new Area
                {
                    Description = "LuoHuQu",
                    TenantId = TenantId
                }
            };
        }

        public void Create()
        {
            CreateAreas();
        }
      
        private void CreateAreas()
        {
            foreach (var area in areas)
            {
                AddIfNotExists(area);
            }
        }

        private void AddIfNotExists(Area area)
        {
            if (VisitContext.Areas.Any(x => x.TenantId == area.TenantId && x.Description == area.Description))
            {
                return;
            }

            VisitContext.Areas.Add(area);
            VisitContext.SaveChanges();
        }
    }
}