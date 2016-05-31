using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.ClientEmployees;
using Bgts.Gps.Maintain.CompanyEmployees;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeeWorkAtCityCreator : DefaultBaseCreator<CompanyEmployeeWorkAtCity>
    {
        public DefaultCompanyEmployeeWorkAtCityCreator(AuthDbContext authContext,
           VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeeWorkAtCity>
            {
                new CompanyEmployeeWorkAtCity
                {
                    CompanyEmployeeId=GetCompanyEmployee().Id,
                    CityId=GetCity().Id

                },new CompanyEmployeeWorkAtCity
                {
                    CompanyEmployeeId=GetCompanyEmployee().Id,
                    CityId=GetCity("GuangZhou").Id
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeeWorkAtCity item)
        {
            if (Table.Any(x => x.CompanyEmployeeId == item.CompanyEmployeeId && x.CityId == item.CityId))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
