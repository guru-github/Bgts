using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.CompanyEmployees;
using System.Collections.Generic;
using System.Linq;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultCompanyEmployeePictureCreator : DefaultBaseCreator<CompanyEmployeePicture>
    {
        public DefaultCompanyEmployeePictureCreator(AuthDbContext authContext,
           VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<CompanyEmployeePicture>
            {
                new CompanyEmployeePicture
                { CompanyEmployeeId = GetCompanyEmployee().Id,
                SeqNo= DefaultCfg.DefaultCompanyEmployeePictureSeqNo,
                FileName = "demo1.jpg",
                Description = "sample decription1"

                },new CompanyEmployeePicture
                {
                    CompanyEmployeeId = GetCompanyEmployee().Id,
                SeqNo = 1234,
                FileName = "demo2.jpg",
                Description = "sample decription"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(CompanyEmployeePicture item)
        {
            if (Table.Any(x => x.SeqNo == item.SeqNo &&
                 x.FileName == item.FileName && x.Description == item.Description))
            {
                return;
            }
            Insert(item);

            VisitContext.SaveChanges();
        }
    }
}
