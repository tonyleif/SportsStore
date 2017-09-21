using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using System.Linq;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernalParam)
        {
            kernel = kernalParam;
            AddBindings();
        }

        public object GetService(Type ServiceType)
        {
            return kernel.TryGet(ServiceType);
        }

        public IEnumerable<object> GetServices(Type ServiceType)
        {
            return kernel.GetAll(ServiceType);
        }

        private void AddBindings()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();

            //mock.Setup(m => m.Products).Returns(new List<Product> {
            //    new Product { Name = "Football", Price = 25 },
            //    new Product { Name = "Surf board", Price = 179 },
            //    new Product { Name = "Running shoes", Price = 95 }
            //});

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}