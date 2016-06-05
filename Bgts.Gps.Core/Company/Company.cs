using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Bcs.Gps.Core.Company
{
    [Table("Company")]
    public class Company : FullAuditedEntity<long>
    {        
        #region Constant Properties
        public const int CompanyNameMaxLength = 64;
        public const int Address1MaxLength = 64;

        public const int Address2MaxLength = 64;
        public const int CityIdMaxLength = 16;

        public const int PhoneNoMaxLength = 16;

        public const int FaxMaxLength = 16;
        public const int MeetingAddress2MaxLength = 64;
        public const int ZipcodeMaxLength = 10;

        public const int DropOffAddress1MaxLength = 64;
        #endregion

        #region Public Properties
        [Key]
        public int? Id { get; set; }
        [StringLength(CompanyNameMaxLength)]
        public string CompanyName { get; set; }

        [StringLength(Address1MaxLength)]
        public string Address1 { get; set; }

        [StringLength(Address2MaxLength)]
        public string Address2 { get; set; }
        public long CityId { get; set; }
        [StringLength(PhoneNoMaxLength)]
        public string PhoneNumber { get; set; }
        [StringLength(FaxMaxLength)]
        public string Fax { get; set; }
        [StringLength(ZipcodeMaxLength)]
        public string Zipcode { get; set; }
        public long? TenantId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        #endregion    
    }
}
