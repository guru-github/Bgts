using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.CompanyEmployees;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeeCreator : DefaultBaseCreator<CompanyEmployee>
    {
        public DefaultCompanyEmployeeCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var cityId = GetCity().Id;
            var areaId = GetArea().Id;

            var list = new List<CompanyEmployee>
            {
                new CompanyEmployee
                {
                    TenantId = TenantId,
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B11).Id,
                    FirstName = "Carl",
                    LastName = "Dai",
                    PhoneNo = DefaultCfg.DefaultCompanyEmployeePhoneNo,
                    CityId = cityId,
                    HomeCityId = cityId,
                    AreaId = areaId
                },new CompanyEmployee
                {
                    TenantId = TenantId,
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B111).Id,
                    FirstName = "Perry",
                    LastName = "Yu",
                    PhoneNo = "13631677633",
                    CityId = cityId,
                        HomeCityId = cityId,
                        AreaId = areaId
                },new CompanyEmployee
                {
                    TenantId = TenantId,
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B111).Id,
                    FirstName = "Danny",
                    LastName = "Li",
                    PhoneNo = "13631677634",
                    CityId = cityId,
                        HomeCityId = cityId,
                        AreaId = areaId
                },new CompanyEmployee
                {
                    TenantId = TenantId,
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B12).Id,
                    FirstName = "Vivien",
                    LastName = "Zhu",
                    PhoneNo = "13631677635",
                    CityId = cityId,
                        HomeCityId = cityId,
                        AreaId = areaId
                },new CompanyEmployee
                {
                    TenantId = TenantId,
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B1).Id,
                    FirstName = "Frank",
                    LastName = "Lin",
                    PhoneNo = "13631677636",
                    CityId = cityId,
                        HomeCityId = cityId,
                        AreaId = areaId
                },new CompanyEmployee
                {
                    TenantId = TenantId,
                    CompanyBranchId = GetCompanyBranch(DefaultCfg.CompanyBranch_B21).Id,
                    FirstName = "JunYin",
                    LastName = "Liu",
                    PhoneNo = "13631677639",
                    CityId = cityId,
                    HomeCityId = cityId,
                    AreaId = areaId
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployee item)
        {
            if (VisitContext.CompanyEmployees.Any(
                x => x.TenantId == item.TenantId && x.FirstName == item.FirstName && 
                 x.LastName == item.LastName && x.PhoneNo == item.PhoneNo))
            {
                return;
            }

            VisitContext.CompanyEmployees.Add(item);
            VisitContext.SaveChanges();
        }
    }
}
