using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Bgts.Gps.Setup.Companies
{
    [Table("Company")]
    public class Company : FullAuditedAndTenantEntity<int>
    {
        public const int CompanyNameMaxLength = 64;
        public const int SymbolMaxLength = 32;
        public const int AddressMaxLength = 64;
        public const int PhoneNoMaxLength = 16;
        public const int FaxMaxLength = 16;
        public const int ZipcodeMaxLength = 10;

        [Required]
        [StringLength(CompanyNameMaxLength)]
        public string CompanyName { get; set; }

        public int? DefaultServiceType { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address1 { get; set; }

        [StringLength(AddressMaxLength)]
        public string Address2 { get; set; }

        [Required]
        public int CityId { get; set; }
        
        [StringLength(PhoneNoMaxLength)]
        public string PhoneNo { get; set; }

        [StringLength(FaxMaxLength)]
        public string Fax { get; set; }

        [StringLength(ZipcodeMaxLength)]
        public string Zipcode { get; set; }
    }
}
