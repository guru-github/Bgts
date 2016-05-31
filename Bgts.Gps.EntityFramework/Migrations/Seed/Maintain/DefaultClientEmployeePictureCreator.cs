using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Maintain.ClientEmployees;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultClientEmployeePictureCreator : DefaultBaseCreator<ClientEmployeePicture>
    {
        public DefaultClientEmployeePictureCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {

        }

        public void Create()
        {
            var list = new List<ClientEmployeePicture>
            {
                new ClientEmployeePicture
                {
                    ClientEmployeeId=GetClientEmployee(DefaultCfg.DefaultClientEmployeePhoneNo).Id,
                    SeqNo= DefaultCfg.DefaultClientEmployeePictureSeqNo,
                    FileName="demo1.jpg",
                    Description="demo description 1"

                },new ClientEmployeePicture
                {
                    ClientEmployeeId=GetClientEmployee(DefaultCfg.DefaultClientEmployeePhoneNo).Id,
                    SeqNo=1231,
                    FileName="demo2.jpg",
                    Description="demo description 2"
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(ClientEmployeePicture item)
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
