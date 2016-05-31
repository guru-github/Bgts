using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Bgts.Gps.Setup.SecurityRequiredLocations
{
    [Table("SecurityRequiredLocation")]
    public class SecurityRequiredLocation : FullAuditedAndTenantEntity<int>
    {
        public const int ZipcodeMaxLength = 10;
        public const int CensusTractMaxLength = 6;
        public const int CensusBlockNumberMaxLength = 4;
        public const int ZipPlus4MaxLength = 4;
        public const int CityMaxLength = 32;
        public const int StateMaxLength = 32;

        [Required]
        [StringLength(ZipcodeMaxLength)]
        public string Zipcode { get; set; }

        [StringLength(CensusTractMaxLength)]
        public string CensusTract { get; set; }

        [StringLength(CensusBlockNumberMaxLength)]
        public string CensusBlockNumber { get; set; }

        [StringLength(ZipPlus4MaxLength)]
        public string ZipPlus4 { get; set; }

        [Required]
        [StringLength(CityMaxLength)]
        public string City { get; set; }

        [Required]
        [StringLength(StateMaxLength)]
        public string State { get; set; }
    }
}
