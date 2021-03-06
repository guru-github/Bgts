using System.Linq;
using Bcs.Gps.EntityFramework;
using Bcs.Gps.MultiTenancy;

namespace Bcs.Gps.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly GpsDbContext _context;

        public DefaultTenantCreator(GpsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = "Default", Name = "Default"});
                _context.SaveChanges();
            }
        }
    }
}