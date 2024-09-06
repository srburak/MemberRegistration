using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;

namespace MemberRegistration.Core.Utilities.Mvc.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory(params INinjectModule[] modules)
        {
            _kernel = new StandardKernel(modules);
        }

        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
}
