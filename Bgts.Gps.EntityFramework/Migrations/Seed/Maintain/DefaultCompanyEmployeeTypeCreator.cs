using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.CompanyEmployeeTypes;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeeTypeCreator : DefaultBaseCreator<CompanyEmployeeType>
    {
        public DefaultCompanyEmployeeTypeCreator(AuthDbContext authContext,
           VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeeType>
            {
                new CompanyEmployeeType
                {
                    Description= "DemoDescription"

                },new CompanyEmployeeType
                {
                   Description= "DemoDescription1"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeeType item)
        {
            if (Table.Any(x => x.Description == item.Description ))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
