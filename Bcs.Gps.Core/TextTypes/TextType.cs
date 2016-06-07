using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bcs.Gps.TextTypes
{
    [Table("TextType")]
    public  class TextType : FullAuditedEntity<Guid>
    {
        #region Constant Properties
        public const int DescriptionMaxLength = 50;
        #endregion

        #region Public Properties
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }
        // public Guid Id { get; set; }
        //public bool IsDeleted { get; set; }
        //public bool DeleterUserId { get; set; }
        //public DateTime DeletionTime { get; set; }
        //public DateTime LastModificationTime { get; set; }
        //public long LastModifierUserId { get; set; }
        //public DateTime CreationTime { get; set; }
        //public long CreatorUserId { get; set; }
        #endregion
    }
}
