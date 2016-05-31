using EntityFramework.DynamicFilters;
using Bgts.Auth.EntityFramework;

namespace Bgts.Auth.TestBase.TestData
{
    public class TestDataBuilder
    {
        private readonly AuthDbContext _context;

        public TestDataBuilder(AuthDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            
            new TestOrganizationUnitsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
