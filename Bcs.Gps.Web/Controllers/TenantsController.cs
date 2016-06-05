using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Bcs.Gps.Authorization;
using Bcs.Gps.MultiTenancy;

namespace Bcs.Gps.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : GpsControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}