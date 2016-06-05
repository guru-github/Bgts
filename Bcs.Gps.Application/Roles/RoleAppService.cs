using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Bcs.Gps.Authorization.Roles;
using Bcs.Gps.Roles.Dto;

namespace Bcs.Gps.Roles
{
    /* THIS IS JUST A SAMPLE. */
    public class RoleAppService : GpsAppServiceBase,IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;

        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
        }

        public async Task UpdateRolePermissions(UpdateRolePermissionsInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }
    }
}