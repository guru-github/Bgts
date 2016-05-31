using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.InactiveReasons;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultInactiveReasonCreator : DefaultBaseCreator<InactiveReason>
    {
        public DefaultInactiveReasonCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<InactiveReason>
            {
                new InactiveReason
                {
                    Description= "DemoDescription"

                },new InactiveReason
                {
                    Description= "Demo Description1"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(InactiveReason item)
        {
            if (Table.Any(x => x.Description == item.Description))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
