using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Bgts.Gps.Setup.Areas
{
    [Table("Area")]
    public class Area : FullAuditedAndTenantEntity<int>
    {
        public const int DescriptionMaxLength = 64;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
