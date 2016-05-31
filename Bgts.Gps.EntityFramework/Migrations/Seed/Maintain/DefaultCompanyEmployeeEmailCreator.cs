using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.CompanyEmployees;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeeEmailCreator : DefaultBaseCreator<CompanyEmployeeEmail>
    {
        public DefaultCompanyEmployeeEmailCreator(AuthDbContext authContext,
           VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeeEmail>
            {
                new CompanyEmployeeEmail
                {
                     CompanyEmployeeId=GetCompanyEmployee().Id,
                Email="koushikhandal@gmail.com",
                FirstName="Koushik",
                LastName="Handal",
                DisplayName="KoushikHandal"

                },new CompanyEmployeeEmail
                {
                      CompanyEmployeeId=GetCompanyEmployee().Id,
                Email="koushikhandal92@gmail.com",
                FirstName="Akash",
                LastName="Roy",
                DisplayName="AkashRoy"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeeEmail item)
        {
            if (Table.Any(x => x.DisplayName == item.DisplayName && x.Email==item.Email))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
