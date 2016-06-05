using System.Threading.Tasks;
using Abp.Application.Services;
using Bcs.Gps.Roles.Dto;

namespace Bcs.Gps.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
