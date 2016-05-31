using System.Data.Common;

namespace Bgts.Auth.Configuration
{
    public class AuthDataModuleConfiguration : IAuthDataModuleConfiguration
    {
        public string NameOrConnectionString { get; set; }
        public DbConnection Connection { get; set; }
    }
}
