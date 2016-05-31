using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Bgts.Gps.Setup.CompanyBranchs;

namespace Bgts.Gps.Setup.CompanyContacts
{
    [Table("CompanyContact")]
    public class CompanyContact : FullAuditedAndTenantEntity<long>, IMayHaveCompanyBranch, IPassivable
    {
        public const int FirstNameMaxLength = 16;
        public const int LastNameMaxLength = 16;
        public const int EmailMaxLength = 32;
        public const int TelNoMaxLength = 16;
        public const int CommetMaxLength = 512;
        
        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; }

        public int? Department { get; set; }

        public int? ContactType { get; set; }

        [StringLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public int TelNo1Type { get; set; }

        [Required]
        [StringLength(TelNoMaxLength)]
        public string TelNo1 { get; set; }

        public int? TelNo2Type { get; set; }

        [StringLength(TelNoMaxLength)]
        public string TelNo2 { get; set; }

        public int? TelNo3Type { get; set; }

        [StringLength(TelNoMaxLength)]
        public string TelNo3 { get; set; }

        public int? TelNo4Type { get; set; }

        [StringLength(TelNoMaxLength)]
        public string TelNo4 { get; set; }

        [StringLength(CommetMaxLength)]
        public string Comment { get; set; }

        public bool IsActive { get; set; }

        public int? CompanyBranchId { get; set; }

        [ForeignKey("CompanyBranchId")]
        public virtual CompanyBranch CompanyBranch { get; set; }
    }
}
