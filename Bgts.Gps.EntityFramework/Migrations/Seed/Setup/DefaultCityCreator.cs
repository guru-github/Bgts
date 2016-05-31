using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.Cities;
using Bgts.Gps.EntityFramework;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultCityCreator : DefaultBaseCreator<City>
    {
        private readonly List<City> cities;

        public DefaultCityCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
            cities = new List<City>
            {
                new City
                {
                    CityName = "GuangZhou",
                    Country = "CN",
                    State = "GuangDong",
                    TimezoneId = GetTimezone().Id,
                    TenantId = TenantId
                },
                new City
                {
                    CityName = DefaultCfg.DefaultCityName,
                    Country = "CN",
                    State = "GuangDong",
                    TimezoneId = GetTimezone().Id,
                    TenantId = TenantId
                }
            };
        }

        public void Create()
        {
            CreateCitys();
        }

        private void CreateCitys()
        {
            foreach (var city in cities)
            {
                AddIfNotExists(city);
            }
        }

        private void AddIfNotExists(City city)
        {
            if (VisitContext.Cities.Any(x => x.TenantId == city.TenantId && x.CityName == city.CityName))
            {
                return;
            }

            VisitContext.Cities.Add(city);
            VisitContext.SaveChanges();
        }
    }
}