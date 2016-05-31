using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.CompanyEmployees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    class DefaultCompanyEmployeeSkillCreator : DefaultBaseCreator<CompanyEmployeeSkill>
    {
        public DefaultCompanyEmployeeSkillCreator(AuthDbContext authContext,
           VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeeSkill>
            {
                new CompanyEmployeeSkill
                {
                    CompanyEmployeeId = GetCompanyEmployee().Id,
                SkillId=GetSkill().Id,
                OtherInfo= "DemoOtherInfo",
                EffectiveDate=DateTime.Parse("2016-08-01 05:00"),
                ExpiryDate=DateTime.Parse("2019-06-01 00:00"),
                CanExpiry=true,
                ProvideBy="Test"

                },new CompanyEmployeeSkill
                {
                     CompanyEmployeeId = GetCompanyEmployee().Id,
                SkillId=GetSkill().Id,
                OtherInfo= "DemoOtherInfo1",
                EffectiveDate=DateTime.Parse("2016-08-01 08:00"),
                ExpiryDate=DateTime.Parse("2019-06-01 01:00"),
                CanExpiry=true,
                ProvideBy="Test1"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeeSkill item)
        {
            if (Table.Any(x => x.SkillId == item.SkillId && x.OtherInfo == item.OtherInfo))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
