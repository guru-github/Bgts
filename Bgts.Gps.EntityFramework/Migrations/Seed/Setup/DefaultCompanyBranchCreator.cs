using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.CompanyBranchs;
using Bgts.Gps.EntityFramework;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultCompanyBranchCreator : DefaultBaseCreator<CompanyBranch>
    {
        public DefaultCompanyBranchCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
        }

        public void Create()
        {
            CreateCompanyBranch();
        }

        private void CreateCompanyBranch()
        {
            var b1 = Create(new CompanyBranch
            {
                BranchName = DefaultCfg.CompanyBranch_B1,
                CompanyId = GetCompany().Id,
                Code = CompanyBranch.CreateCode(1),
                ContactName = "Arvin",
                ContactPhone = "123321332",
                Address1 = "GuangDong"
            });

            var b11 = Create(new CompanyBranch
            {
                BranchName = DefaultCfg.CompanyBranch_B11,
                CompanyId = GetCompany().Id,
                Code = CompanyBranch.CreateCode(1, 1),
                Address1 = "ShenZhen",
                ContactName = "Carl",
                ContactPhone = "123321343",
                ParentId = b1.Id
            });

            var b12 = Create(new CompanyBranch
            {
                BranchName = DefaultCfg.CompanyBranch_B12,
                CompanyId = GetCompany().Id,
                Code = CompanyBranch.CreateCode(1, 2),
                Address1 = "DongGuang",
                ContactName = "Lucy",
                ContactPhone = "1233214322",
                ParentId = b1.Id
            });

            var b111 = Create(new CompanyBranch
            {
                BranchName = DefaultCfg.CompanyBranch_B111,
                CompanyId = GetCompany().Id,
                Code = CompanyBranch.CreateCode(1, 1, 1),
                Address1 = "FuShan",
                ContactName = "Jack",
                ContactPhone = "123321444",
                ParentId = b11.Id
            });

            var b112 = Create(new CompanyBranch
            {
                BranchName = DefaultCfg.CompanyBranch_B112,
                CompanyId = GetCompany().Id,
                Code = CompanyBranch.CreateCode(1, 1, 2),
                Address1 = "ZhongShan",
                ContactName = "Perry",
                ContactPhone = "134123341",
                ParentId = b11.Id
            });

            var b2 = Create(new CompanyBranch
            {
                BranchName = DefaultCfg.CompanyBranch_B2,
                CompanyId = GetCompany().Id,
                Address1 = "FuTian",
                ContactName = "John",
                ContactPhone = "1233214523",
                Code = CompanyBranch.CreateCode(2)
            });

            var b21 = Create(new CompanyBranch
            {
                BranchName = DefaultCfg.CompanyBranch_B21,
                CompanyId = GetCompany().Id,
                Code = CompanyBranch.CreateCode(2, 1),
                Address1 = "NanShan",
                ContactName = "Frank",
                ContactPhone = "13424223777",
                ParentId = b2.Id
            });
        }

        private CompanyBranch Create(CompanyBranch entity)
        {
            entity.TenantId = TenantId;

            if (VisitContext.CompanyBranchs.Any(x => x.TenantId == entity.TenantId && 
                x.BranchName == entity.BranchName))
            {
               
                return VisitContext.CompanyBranchs.FirstOrDefault(x => x.TenantId == entity.TenantId &&
                                    x.BranchName == entity.BranchName);
            }

            var branch = VisitContext.CompanyBranchs.Add(entity);
            VisitContext.SaveChanges();

            return branch;
        }
    }
}