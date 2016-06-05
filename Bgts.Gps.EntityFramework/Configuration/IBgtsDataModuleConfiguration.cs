using System.Data.Common;

namespace Bgts.Gps.Configuration
{
    public interface IBgtsDataModuleConfiguration
    {
        string NameOrConnectionString { get; set; }
        DbConnection Connection { get; set; }
    }
}
