using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;

using SportTracker.Domain.Abstract;
using SportTracker.Domain.Concrete;
using SportTracker.Domain.Entities;
using SportTracker.WebUI.Infrastructure.Abstract;
using SportTracker.WebUI.Infrastructure.Concrete;

namespace SportTracker.WebUI.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;
		public NinjectDependencyResolver()
		{
			kernel = new StandardKernel();
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
			kernel.Bind<IMuscleRepository>().To<EFMuscleRepository>();
			kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
		}
	}
}