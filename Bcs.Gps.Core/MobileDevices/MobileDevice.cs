using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bcs.Gps.MobileDevices
{
    [Table("MobileDevice")]
    public class MobileDevice : FullAuditedEntity<Guid>
    {

        #region Constant Properties
        public const int DeviceHardwareIdMaxLength = 25;
        public const int CellPhoneNumberMaxLength = 16;
        #endregion

        #region Public Properties
        public long PersonnelId { get; set; }
        [StringLength(DeviceHardwareIdMaxLength)]
        public string DeviceHardwareId { get; set; }
        [StringLength(CellPhoneNumberMaxLength)]
        public string CellPhoneNumber { get; set; }
        public long TenantId { get; set; }
        //public new Guid Id { get; set; }
        // public bool IsDeleted { get; set; }
        //public long DeleterUserId { get; set; }
        //public DateTime DeletionTime { get; set; }
        // public DateTime LastModificationTime { get; set; }
        //public long LastModifierUserId { get; set; }
        //public DateTime CreationTime { get; set; }
        //public long CreatorUserId { get; set; }
        #endregion
    }
}

