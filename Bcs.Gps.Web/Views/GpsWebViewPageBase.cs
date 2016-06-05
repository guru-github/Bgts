using Abp.Web.Mvc.Views;

namespace Bcs.Gps.Web.Views
{
    public abstract class GpsWebViewPageBase : GpsWebViewPageBase<dynamic>
    {

    }

    public abstract class GpsWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected GpsWebViewPageBase()
        {
            LocalizationSourceName = GpsConsts.LocalizationSourceName;
        }
    }
}