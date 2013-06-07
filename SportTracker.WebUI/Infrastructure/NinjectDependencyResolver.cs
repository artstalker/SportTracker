#region using
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using SportTracker.Domain;
using SportTracker.Domain.Abstract;
using SportTracker.WebUI.Infrastructure.Abstract;
using SportTracker.WebUI.Infrastructure.Concrete;

#endregion

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
         kernel.Bind<IMuscleRepository>().To<ModelSportTrackerContainer>();
         kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
      }		
	}
}