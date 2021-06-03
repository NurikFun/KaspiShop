using AW.Domain.Interfaces;
using AW.Infrastructure.Business;
using AW.Infrastructure.Data.CustomRepository;
using AW.Infrastructure.Data.Repository;
using AW.Services.Interfaces;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

namespace WCFShopService
{
    public class Global : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind<IProductCatalogRepository>().To<ProductCatalogRepository>();
            kernel.Bind<IShoppingAddress>().To<ShoppingAddress>();
            kernel.Bind<IOrderProcessor>().To<OrderProcessor>();
            kernel.Bind<IOrderDisplay>().To<OrderDisplay>();
            kernel.Bind<INotificationSender>().To<MailSender>();

            return kernel;
        }
    }
}