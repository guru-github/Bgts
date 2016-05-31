using EntityFramework.DynamicFilters;
using Bgts.Auth.EntityFramework;

namespace Bgts.Auth.Migrations.Seed
{
    public class InitialDbBuilder
    {
        private readonly AuthDbContext _context;

        public InitialDbBuilder(AuthDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new DefaultTenantRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
