using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Bgts.Gps.Setup.Skills
{
    [Table("Skill")]
    public class Skill : FullAuditedAndTenantEntity<int>
    {
        public const int DescriptionMaxLength = 64;
        [Required]
        public int SkillType { get; set; }
        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
