using System;
using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;
using Bgts.Gps.Maintain.Clients;

namespace Bgts.Gps.Migrations.Seed.Maintain
{
    public class DefaultClientCreator : DefaultBaseCreator<Client>
    {
        public DefaultClientCreator(AuthDbContext authContext, VhasDbContext context) :
            base(authContext, context)
        {
        }

        public void Create()
        {
            var list = new List<Client>
            {
                new Client
                {
                    Name = DefaultCfg.DefaultClientName,
                    DefaultServiceType = (int)ServiceTypes.Normal,
                    StartTime = DateTime.Parse("2016-01-01 00:00"),
                    EndTime = DateTime.Parse("2016-01-01 00:00").AddYears(2),
                    Address1 = "NanShan Round, NanShan Area, ShenZhen",
                    CityId = GetCity().Id,
                    Zipcode = "510000",
                    Email = "NanSha@163.com",
                    ContactName = "NanShan",
                    ContactPhone = "12332341234",
                    PaymentTerms = (int)PaymentTermTypes.COD,
                    TenantId = TenantId
                },
                new Client
                {
                    Name = "FuTian Hospital",
                    DefaultServiceType = (int)ServiceTypes.Normal,
                    StartTime = DateTime.Parse("2016-04-05 00:00"),
                    EndTime = DateTime.Parse("2016-04-05 00:00").AddYears(1),
                    Address1 = "CaiTian Round, FuTian Area, ShenZhen",
                    CityId = GetCity().Id,
                    Zipcode = "510000",
                    Email = "FuTian@126.com",
                    ContactName = "FuTian",
                    ContactPhone = "33234124",
                    PaymentTerms = (int)PaymentTermTypes.COD,
                    TenantId = TenantId
                }
            };

            foreach (var item in list)
            {
                AddIfNotExists(item);
            }
        }

        private void AddIfNotExists(Client item)
        {
            if (Table.Any(x => x.Name == item.Name && x.TenantId == TenantId))
            {
                return;
            }

            Insert(item);
            VisitContext.SaveChanges();
        } 
    }
}
