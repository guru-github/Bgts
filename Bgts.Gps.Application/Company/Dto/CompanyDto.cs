using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bgts.Gps.Company.Dto
{
    class CompanyDto
    {
        public int? Id { get; set; }
        [StringLength(64)]
        public string CompanyName { get; set; }

        [StringLength(64)]
        public string Address1 { get; set; }

        [StringLength(64)]
        public string Address2 { get; set; }
        public long CityId { get; set; }
        [StringLength(16)]
        public string PhoneNumber { get; set; }
        [StringLength(16)]
        public string Fax { get; set; }
        [StringLength(16)]
        public string Zipcode { get; set; }
        public long? TenantId { get; set; }
        public bool? IsDeleted { get; set; }       
        
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
