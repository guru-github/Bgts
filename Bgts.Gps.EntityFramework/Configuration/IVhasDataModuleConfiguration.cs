using System.Data.Common;

namespace Bgts.Gps.Configuration
{
    public interface IVhasDataModuleConfiguration
    {
        string NameOrConnectionString { get; set; }
        DbConnection Connection { get; set; }
    }
}
