using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Bgts.Gps.Setup.CompanyBranchUsers
{
    [Table("CompanyBranchUser")]
    public class CompanyBranchUser : CreationAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public long? UserId { get; set; }

        public int? CompanyBranchId { get; set; }

        public CompanyBranchUser()
        {

        }

        public CompanyBranchUser(int? tenantId, long userId, int branchId)
        {
            TenantId = tenantId;
            UserId = userId;
            CompanyBranchId = branchId;
        }
    }
}
