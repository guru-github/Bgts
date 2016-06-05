using System.Web.Mvc;

namespace Bcs.Gps.Web.Controllers
{
    public class AboutController : GpsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}