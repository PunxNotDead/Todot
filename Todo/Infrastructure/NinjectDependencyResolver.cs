using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Todo.Repositories;
using Todo.Interfaces;

namespace Todo.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		protected IKernel kernel;

		public NinjectDependencyResolver(IKernel param) { 
			kernel = param;
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
			kernel.Bind<IUserRepository>().To<UserRepository>();
		}
	}
}