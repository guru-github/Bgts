using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Bgts.Gps.Setup.Cities;
using Bgts.Gps.Setup.CompanyBranchs;

namespace Bgts.Gps.Setup.Patients
{
    [Table("Patient")]
    public class Patient : FullAuditedAndTenantEntity<long>, IMayHaveCompanyBranch
    {
        public const int FirstNameMaxLength = 16;
        public const int LastNameMaxLength = 16;
        public const int AddressMaxLength = 128;
        public const int ZipcodeMaxLength = 10;
        public const int CensusTractMaxLength = 6;
        public const int CensusBlockNumberMaxLength = 4;

        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required]
        [StringLength(ZipcodeMaxLength)]
        public string Zipcode { get; set; }

        [StringLength(CensusTractMaxLength)]
        public string CensusTract { get; set; }

        [StringLength(CensusBlockNumberMaxLength)]
        public string CensusBlockNumber { get; set; }

        public int? CompanyBranchId { get; set; }
    }
}
