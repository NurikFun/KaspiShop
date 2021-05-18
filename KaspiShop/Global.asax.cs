using AW.Domain.Core;
using KaspiShop.ShopCartItemService;
using KaspiShop.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KaspiShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(ShopCartItemServiceClient), new ShopCartItemBinder());

        }
    }
}
