using System.Data.Common;

namespace Bgts.Auth.Configuration
{
    public interface IAuthDataModuleConfiguration
    {
        string NameOrConnectionString { get; set; }

        DbConnection Connection { get; set; }
    }
}
