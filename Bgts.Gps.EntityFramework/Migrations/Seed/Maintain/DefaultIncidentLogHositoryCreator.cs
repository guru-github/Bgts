using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;
using Bgts.Gps.Maintain.IncidentLogs;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultIncidentLogHositoryCreator : DefaultBaseCreator<IncidentLogHistory>
    {
        public DefaultIncidentLogHositoryCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<IncidentLogHistory>
            {
                new IncidentLogHistory
                {
                    IncidentLogId =DefaultCfg.DefaultIncidentLogId,
                    IncidentAction = (int)IncidentActionTypes.Created,
                    Comment = "Test for log history"

                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(IncidentLogHistory item)
        {
            if (Table.Any(x => x.Comment == item.Comment))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
