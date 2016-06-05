using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Bcs.Gps.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : GpsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}