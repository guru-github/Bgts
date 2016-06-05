using Abp.Authorization;
using Bcs.Gps.Authorization.Roles;
using Bcs.Gps.MultiTenancy;
using Bcs.Gps.Users;

namespace Bcs.Gps.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
