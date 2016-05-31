using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.CompanyBranchUsers;
using Bgts.Gps.EntityFramework;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultCompanyBranchUserCreator: DefaultBaseCreator<CompanyBranchUser>
    {
        public DefaultCompanyBranchUserCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            CreateCompanyBranchUser();
        }

        private void CreateCompanyBranchUser()
        {
            var b1 = GetCompanyBranch(DefaultCfg.CompanyBranch_B1).Id;
            var b11 = GetCompanyBranch(DefaultCfg.CompanyBranch_B11).Id;
            var b111 = GetCompanyBranch(DefaultCfg.CompanyBranch_B111).Id;
            var b112 = GetCompanyBranch(DefaultCfg.CompanyBranch_B112).Id;
            var b12 = GetCompanyBranch(DefaultCfg.CompanyBranch_B12).Id;
            var b2 = GetCompanyBranch(DefaultCfg.CompanyBranch_B2).Id;
            var b21 = GetCompanyBranch(DefaultCfg.CompanyBranch_B21).Id;

            AssignUserToCompanyBranch(b11);
            AssignUserToCompanyBranch(b111);
            AssignUserToCompanyBranch(b12);
            AssignUserToCompanyBranch(b21);
        }

        private void AssignUserToCompanyBranch(int branchId)
        {
            var ub = new CompanyBranchUser(TenantId, UserId ?? 0, branchId);

            if (VisitContext.CompanyBranchUsers.Any(x => x.TenantId == TenantId && 
                x.UserId == ub.UserId && 
                x.CompanyBranchId == ub.CompanyBranchId))
            {
                return;
            }

            VisitContext.CompanyBranchUsers.Add(ub);
            VisitContext.SaveChanges();
        }
    }
}
