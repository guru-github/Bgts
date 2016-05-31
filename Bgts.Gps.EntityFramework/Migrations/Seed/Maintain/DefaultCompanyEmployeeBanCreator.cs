using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;
using Bgts.Gps.Maintain.CompanyEmployees;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeeBanCreator : DefaultBaseCreator<CompanyEmployeeBan>
    {
        public DefaultCompanyEmployeeBanCreator(AuthDbContext authContext,
           VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeeBan>
            {
                new CompanyEmployeeBan
                {
                     CompanyEmployeeId = GetCompanyEmployee().Id,
                ClientId=GetClient().Id,
                BanAction=(int)BanActionTypes.CanNotWorkWithOrAt,
                BanType= (int)BanTypes.Client,
                ClientBranchId=GetClientBranch().Id,
                Reason="DemoReason"

                },new CompanyEmployeeBan
                {
                      CompanyEmployeeId = GetCompanyEmployee().Id,
                ClientId=GetClient().Id,
                BanAction=(int)BanActionTypes.CanNotWorkWithOrAt,
                BanType= (int)BanTypes.Client,
                ClientBranchId=GetClientBranch().Id,
                Reason="DemoReason1"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeeBan item)
        {
            if (Table.Any(x => x.Reason == item.Reason))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
