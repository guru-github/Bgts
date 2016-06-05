using System.Data.Common;

namespace Bgts.Gps.Configuration
{
    public class BgtsDataModuleConfiguration : IBgtsDataModuleConfiguration
    {
        public string NameOrConnectionString { get; set; }
        public DbConnection Connection { get; set; }
    }
}
