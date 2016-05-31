using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;
using Bgts.Gps.Maintain.ClientBranchs;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultClientBranchCreator : DefaultBaseCreator<ClientBranch>
    {
        public DefaultClientBranchCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
        }

        public void Create()
        {
            CreateClientBranch();
        }

        private void CreateClientBranch()
        {
            var b1 = AddIfNotExists(new ClientBranch
            {
                ClientId = GetClient().Id,
                BranchName = DefaultCfg.ClientBranch_B1,
                Code = ClientBranch.CreateCode(1),
                ServiceType = (int) ServiceTypes.Normal,
                Address1 = "GuangDong",
                CityId = GetCity().Id,
                ContactName = "Arvin",
                ContactPhone = "123321332",
                TenantId = TenantId
            });

            var b11 = AddIfNotExists(new ClientBranch
            {
                ClientId = GetClient().Id,
                TenantId = TenantId,
                BranchName = DefaultCfg.ClientBranch_B11,
                Code = ClientBranch.CreateCode(1, 1),
                ServiceType = (int) ServiceTypes.Normal,
                Address1 = "ShenZhen",
                CityId = GetCity().Id,
                ContactName = "Carl",
                ContactPhone = "123321343",
                ParentId = b1.Id
            });

            var b12 = AddIfNotExists(new ClientBranch
            {
                TenantId = TenantId,
                ClientId = GetClient().Id,
                BranchName = DefaultCfg.ClientBranch_B12,
                Code = ClientBranch.CreateCode(1, 2),
                ServiceType = (int)ServiceTypes.Normal,
                Address1 = "DongGuang",
                CityId = GetCity().Id,
                ContactName = "Lucy",
                ContactPhone = "1233214322",
                ParentId = b1.Id
            });

            var b111 = AddIfNotExists(new ClientBranch
            {
                TenantId = TenantId,
                ClientId = GetClient().Id,
                BranchName = DefaultCfg.ClientBranch_B111,
                Code = ClientBranch.CreateCode(1, 1, 1),
                ServiceType = (int)ServiceTypes.Normal,
                Address1 = "FuShan",
                CityId = GetCity().Id,
                ContactName = "Jack",
                ContactPhone = "123321444",
                ParentId = b11.Id
            });

            var b112 = AddIfNotExists(new ClientBranch
            {
                TenantId = TenantId,
                ClientId = GetClient().Id,
                BranchName = DefaultCfg.ClientBranch_B112,
                Code = ClientBranch.CreateCode(1, 1, 2),
                ServiceType = (int)ServiceTypes.Normal,
                Address1 = "ZhongShan",
                CityId = GetCity().Id,
                ContactName = "Perry",
                ContactPhone = "134123341",
                ParentId = b11.Id
            });

            var b2 = AddIfNotExists(new ClientBranch
            {
                TenantId = TenantId,
                ClientId = GetClient().Id,
                BranchName = DefaultCfg.ClientBranch_B2,
                Code = ClientBranch.CreateCode(2),
                ServiceType = (int)ServiceTypes.Normal,
                Address1 = "FuTian",
                CityId = GetCity().Id,
                ContactName = "John",
                ContactPhone = "1233214523"
            });

            var b21 = AddIfNotExists(new ClientBranch
            {
                TenantId = TenantId,
                ClientId = GetClient().Id,
                BranchName = DefaultCfg.ClientBranch_B21,
                Code = ClientBranch.CreateCode(2, 1),
                ServiceType = (int)ServiceTypes.Normal,
                Address1 = "NanShan",
                CityId = GetCity().Id,
                ContactName = "Frank",
                ContactPhone = "13424223777",
                ParentId = b2.Id
            });
        }

        private ClientBranch AddIfNotExists(ClientBranch item)
        {
            if (Table.Any(x => x.BranchName == item.BranchName && x.TenantId == TenantId))
            {
                return item;
            }

            var branch = Insert(item);
            VisitContext.SaveChanges();
            return branch;
        } 
    }
}