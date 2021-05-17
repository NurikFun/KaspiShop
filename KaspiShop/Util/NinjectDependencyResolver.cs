using AW.Domain.Core;
using AW.Domain.Interfaces;
using AW.Infrastructure.Business;
using AW.Infrastructure.Data.CustomRepository;
using AW.Infrastructure.Data.Repository;
using AW.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind<IProductCatalogRepository>().To<ProductCatalogRepository>();
            kernel.Bind<IOrderProcessor>().To<OrderProcessor>();
            kernel.Bind<IRegisterUser>().To<RegisterUser>();
            kernel.Bind<TestService.ITest>().To<TestService.TestClient>();
        }
    }
}