using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcs.Gps.Company.Dto
{
    public class GetCompanyDetailForEditOutput : EntityDto<long?>, IInputDto
    {
        [StringLength(Bcs.Gps.Companies.Company.CompanyNameMaxLength)]
        public string CompanyName { get; set; }
        [StringLength(Bcs.Gps.Companies.Company.Address1MaxLength)]
        public string Address1 { get; set; }
        [StringLength(Bcs.Gps.Companies.Company.Address2MaxLength)]
        public string Address2 { get; set; }
        public long? CityId { get; set; }
        [StringLength(Bcs.Gps.Companies.Company.PhoneNoMaxLength)]
        public string PhoneNumber { get; set; }
        [StringLength(Bcs.Gps.Companies.Company.FaxMaxLength)]
        public string Fax { get; set; }
        [StringLength(Bcs.Gps.Companies.Company.ZipcodeMaxLength)]
        public string Zipcode { get; set; }
    }
}
