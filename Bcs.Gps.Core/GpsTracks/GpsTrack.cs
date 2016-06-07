using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bcs.Gps.GpsTracks
{
    [Table("GpsTrack")]
    public class GpsTrack : FullAuditedEntity<Guid>
    {
        #region Constant Properties
        #endregion

        #region Public Properties
        public DateTime TrackTime { get; set; }
        public Decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Direction { get; set; }
        public long PersonnelId { get; set; }
        public long MobileDeviceId { get; set; }
        public long ApplicationId { get; set; }
        public long EventId { get; set; }
        public long TagValueId { get; set; }
        public long TextValueId { get; set; }
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
