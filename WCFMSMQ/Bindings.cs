using AW.Domain.Interfaces;
using AW.Infrastructure.Business;
using AW.Infrastructure.Data.Repository;
using AW.Services.Interfaces;
using Ninject.Modules;

namespace WCFMSMQ
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            Bind<IXMLUtility>().To<XMLDoc>();
        }
    }
}
