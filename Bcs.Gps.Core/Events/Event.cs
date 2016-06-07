using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bcs.Gps.Events
{
    [Table("Event")]
    public class Event : FullAuditedEntity<Guid>
    {

        #region Constant Properties
        public const int DescriptionMaxLength = 50;
        #endregion

        #region Public Properties
        public long ApplicationId { get; set; }
        public long EventCode { get; set; }
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }
        public long TenantId { get; set; }
        // public Guid Id { get; set; }
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
