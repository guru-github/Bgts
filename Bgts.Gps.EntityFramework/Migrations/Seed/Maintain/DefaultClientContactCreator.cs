using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;
using Bgts.Gps.Maintain.ClientContacts;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultClientContactCreator : DefaultBaseCreator<ClientContact>
    {
        private readonly List<ClientContact> contacts;

        public DefaultClientContactCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
            contacts = new List<ClientContact>
            {
                new ClientContact
                {
                    FirstName = "Carl",
                    LastName = "Dai",
                    Email = DefaultCfg.DefaultClientContactEmail,
                    TelNo1Type = (int) TelNoTypes.Home,
                    TelNo1 = "335522218",
                    ClientBranchId = GetClientBranch(DefaultCfg.ClientBranch_B11).Id,
                    TenantId = TenantId
                },new ClientContact
                {
                    TelNo1Type = (int) TelNoTypes.Work,
                    TelNo1 = "2231341234",
                    FirstName = "Perry",
                    LastName = "Yu",
                    Email = "perryyu@163.com",
                    ClientBranchId = GetCompanyBranch(DefaultCfg.ClientBranch_B11).Id,
                    TenantId = TenantId
                },new ClientContact
                {
                    TelNo1Type = (int) TelNoTypes.Work,
                    TelNo1 = "1234231423",
                    FirstName = "danny",
                    LastName = "li",
                    Email = "dannyli@163.com",
                    ClientBranchId = GetCompanyBranch(DefaultCfg.ClientBranch_B1).Id,
                    TenantId = TenantId
                }
            };
        }

        public void Create()
        {
            foreach (var contact in contacts)
            {
                AddIfNotExists(contact);
            }
        }
       
        private void AddIfNotExists(ClientContact item)
        {
            if (Table.Any(x => x.Email == item.Email && x.TenantId == TenantId))
            {
                return;
            }
            Insert(item);
            VisitContext.SaveChanges();
        }
    }
}