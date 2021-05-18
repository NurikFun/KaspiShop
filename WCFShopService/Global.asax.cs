using AW.Domain.Interfaces;
using AW.Infrastructure.Data.CustomRepository;
using AW.Infrastructure.Data.Repository;
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
            return kernel;
        }
    }
}