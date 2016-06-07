using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bcs.Gps.TagValues
{
    [Table("TagValue")]
   public class TagValue : FullAuditedEntity<Guid>
    {
        #region Constant Properties
        public const int TagIdMaxLength = 50;
        #endregion

        #region Public Properties
        public long TagTypeId { get; set; }
        [StringLength(TagIdMaxLength)]
        public string TagId { get; set; }
        public long TenantId { get; set; }
        //public Guid Id { get; set; }
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
