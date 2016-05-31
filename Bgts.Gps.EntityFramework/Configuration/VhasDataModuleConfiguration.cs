using System.Data.Common;

namespace Bgts.Gps.Configuration
{
    public class VhasDataModuleConfiguration : IVhasDataModuleConfiguration
    {
        public string NameOrConnectionString { get; set; }
        public DbConnection Connection { get; set; }
    }
}
