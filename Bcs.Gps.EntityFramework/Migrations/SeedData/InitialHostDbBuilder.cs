using Bcs.Gps.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Bcs.Gps.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly GpsDbContext _context;

        public InitialHostDbBuilder(GpsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
