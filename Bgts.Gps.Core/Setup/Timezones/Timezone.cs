using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Bgts.Gps.Setup.Timezones
{
    [Table("Timezone")]
    public class Timezone : FullAuditedAndTenantEntity<int>
    {
        public const int TimezonCodeMaxLength = 6;
        public const int DescriptionMaxLength = 32;

        [Required]
        [StringLength(TimezonCodeMaxLength)]
        public string TimezoneCode { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public bool? IsNegativeGMT { get; set; }

        [Required]
        public int? GMTOffsetTime { get; set; }


        public int? DaylightSaving { get; set; }
    }
}
