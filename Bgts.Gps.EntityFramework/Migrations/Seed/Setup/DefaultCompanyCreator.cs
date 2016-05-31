using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.Companies;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultCompanyCreator : DefaultBaseCreator<Company>
    {
        private readonly Company company;

        public DefaultCompanyCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
            company = new Company
            {
                CompanyName = DefaultCfg.DefaultCompanyName,
                Address1 = "Nanshan",
                CityId = GetCity().Id,
                DefaultServiceType = (int) ServiceTypes.Normal,
                PhoneNo = "13631677673",
                Zipcode = "510000",
                Fax = "1234124123",
                TenantId = TenantId
            };
        }

        public void Create()
        {
            CreateCompanies();
        }

        private void CreateCompanies()
        {
            if (VisitContext.Companies.Any(x => x.TenantId == company.TenantId && x.CompanyName == company.CompanyName))
            {
                return;
            }
            VisitContext.Companies.Add(company);
            VisitContext.SaveChanges();
        }
    }
}