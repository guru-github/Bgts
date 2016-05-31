using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;
using Bgts.Gps.Maintain.CompanyEmployees;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeeTelephoneCreator : DefaultBaseCreator<CompanyEmployeeTelephone>
    {
        public DefaultCompanyEmployeeTelephoneCreator(AuthDbContext authContext,
           VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeeTelephone>
            {
                new CompanyEmployeeTelephone
                {
                     TelType = (int)TelNoTypes.Mobile,
                SeqNo =DefaultCfg.DefaultCompanyEmployeeTelephoneSeqNo,
                PhoneNo="9564578400",
                Comment="TestComment",
                CompanyEmployeeId = GetCompanyEmployee().Id

                },new CompanyEmployeeTelephone
                {
                    TelType = (int)TelNoTypes.Mobile,
                SeqNo = 1209,
                PhoneNo="9564578401",
                Comment="TestComment1",
                CompanyEmployeeId = GetCompanyEmployee().Id
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeeTelephone item)
        {
            if (Table.Any(x => x.SeqNo == item.SeqNo &&
                 x.PhoneNo == item.PhoneNo && x.Comment == item.Comment))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
