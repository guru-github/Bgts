using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.ClientEmployees;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultClientEmployeeCreator : DefaultBaseCreator<ClientEmployee>
    {
        public DefaultClientEmployeeCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var cityId = GetCity().Id;
            var list = new List<ClientEmployee>
            {
                new ClientEmployee
                {
                    TenantId = TenantId,
                    ClientBranchId = GetClientBranch(DefaultCfg.ClientBranch_B11).Id,
                    FirstName = "John",
                    LastName = "Dai",
                    Address1 = "NanShan",
                    PhoneNo = DefaultCfg.DefaultClientEmployeePhoneNo,
                    CityId = cityId
                },new ClientEmployee
                {
                    TenantId = TenantId,
                    ClientBranchId = GetClientBranch(DefaultCfg.ClientBranch_B111).Id,
                    FirstName = "Lucy",
                    LastName = "Yu",
                    Address1 = "NanShan",
                    PhoneNo = "13631677633",
                    CityId = cityId
                },new ClientEmployee
                {
                    TenantId = TenantId,
                    ClientBranchId = GetClientBranch(DefaultCfg.ClientBranch_B111).Id,
                    FirstName = "Jack",
                    LastName = "Li",
                    Address1 = "NanShan",
                    PhoneNo = "13631677634",
                    CityId = cityId
                },new ClientEmployee
                {
                    TenantId = TenantId,
                    ClientBranchId = GetClientBranch(DefaultCfg.ClientBranch_B12).Id,
                    FirstName = "Joe",
                    LastName = "Zhu",
                    Address1 = "NanShan",
                    PhoneNo = "13631677635",
                    CityId = cityId
                },new ClientEmployee
                {
                    TenantId = TenantId,
                    ClientBranchId = GetClientBranch(DefaultCfg.ClientBranch_B1).Id,
                    FirstName = "Peter",
                    LastName = "Lin",
                    Address1 = "NanShan",
                    PhoneNo = "13631677636",
                    CityId = cityId
                },new ClientEmployee
                {
                    TenantId = TenantId,
                    ClientBranchId = GetClientBranch(DefaultCfg.ClientBranch_B21).Id,
                    FirstName = "Owen",
                    LastName = "Liu",
                    Address1 = "NanShan",
                    PhoneNo = "13631677639",
                    CityId = cityId
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(ClientEmployee item)
        {
            if (Table.Any(x => x.FirstName == item.FirstName && 
                 x.LastName == item.LastName && x.PhoneNo == item.PhoneNo && x.TenantId == item.TenantId))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
