using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Bgts.Gps.Setup.Timezones;

namespace Bgts.Gps.Setup.Cities
{
    [Table("City")]
    public class City : FullAuditedAndTenantEntity<int>
    {
        public const int CityNameMaxLength = 32;
        public const int StateMaxLength = 32;
        public const int CountryMaxLength = 8;

        [Required]
        [StringLength(CityNameMaxLength)]
        public string CityName { get; set; }

        [Required]
        [StringLength(StateMaxLength)]
        public string State { get; set; }

        [Required]
        [StringLength(CountryMaxLength)]
        public string Country { get; set; }

        [Required]
        public int TimezoneId { get; set; }

        [ForeignKey("TimezoneId")]
        public virtual Timezone Timezone { get; set; }
    }
}
