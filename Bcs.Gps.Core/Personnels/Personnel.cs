using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bcs.Gps.Personnels
{
    [Table("Personnel")]
    public class Personnel : FullAuditedEntity<long>
    {
        #region Constant Properties
        public const int FirstNameMaxLength = 16;
        public const int MiddleInitialMaxLength = 16;
        public const int LastNameMaxLength = 16;
        public const int Address1MaxLength = 128;
        public const int Address2MaxLength = 128;
        public const int ZipcodeMaxLength = 10;



        #endregion

        #region Public Properties
        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; }
        [StringLength(MiddleInitialMaxLength)]
        public string MiddleInitial { get; set; }
        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; }
        [StringLength(Address1MaxLength)]
        public string Address1 { get; set; }
        [StringLength(Address2MaxLength)]
        public string Address2 { get; set; }
        public long CityId { get; set; }
        [StringLength(ZipcodeMaxLength)]
        public string Zipcode { get; set; }
        public bool IsActive { get; set; }
        public long TenantId { get; set; }
        // public long Id { get; set; }
        //public bool IsDeleted { get; set; }
        //public long DeleterUserId { get; set; }
        //public DateTime DeletionTime { get; set; }
        //public DateTime LastModificationTime { get; set; }
        //public long LastModifierUserId { get; set; }
        //public DateTime CreationTime { get; set; }
        //public long CreatorUserId { get; set; }
        #endregion
    }
}
