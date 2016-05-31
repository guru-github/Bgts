using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.CompanyContacts;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultCompanyContactCreator : DefaultBaseCreator<CompanyContact>
    {
        private readonly List<CompanyContact> contacts;

        public DefaultCompanyContactCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
            contacts = new List<CompanyContact>
            {
                new CompanyContact
                {
                    FirstName = "Carl",
                    LastName = "Dai",
                    Email = DefaultCfg.DefaultCompanyContactEmail,
                    TelNo1Type = (int) TelNoTypes.Home,
                    TelNo1 = "335522218",
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B11).Id,
                    TenantId = TenantId
                },new CompanyContact
                {
                    TelNo1Type = (int) TelNoTypes.Work,
                    TelNo1 = "2231341234",
                    FirstName = "Perry",
                    LastName = "Yu",
                    Email = "perryyu@bcsint.com",
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B11).Id,
                    TenantId = TenantId
                },new CompanyContact
                {
                    TelNo1Type = (int) TelNoTypes.Work,
                    TelNo1 = "1234231423",
                    FirstName = "danny",
                    LastName = "li",
                    Email = "dannyli@bcsint.com",
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B1).Id,
                    TenantId = TenantId
                }
            };
        }

        public void Create()
        {
            CreateCompanyContacts();
        }

        private void CreateCompanyContacts()
        {
            foreach (var contact in contacts)
            {
                AddIfNotExists(contact);
            }
        }

        private void AddIfNotExists(CompanyContact contact)
        {
            if (VisitContext.CompanyContacts.Any(x => x.TenantId == contact.TenantId && x.Email == contact.Email))
            {
                return;
            }

            VisitContext.CompanyContacts.Add(contact);
            VisitContext.SaveChanges();
        }
    }
}