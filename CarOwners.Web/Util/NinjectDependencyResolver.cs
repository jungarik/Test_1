using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception;
using System.Web.Mvc;
using CarOwners.Domain.Abstract;
using CarOwners.Domain.Concrete;

namespace CarOwners.Web.Util
{
    public class NinjectDependencyResolver: IDependencyResolver
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
            kernel.Bind<IUnitOfWork>().To<UoW>();
            kernel.Bind<IOwnersRepository>().To<OwnerRepository>();
            kernel.Bind<ICarsRepository>().To<CarRepository>();
            kernel.Bind<IRepositoryFactory>().ToFactory();
        }
    }
}