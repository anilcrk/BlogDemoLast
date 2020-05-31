using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace DemoFramework.Core.Utilities.Infrastructure
{
 public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _kernel;
        public NinjectControllerFactory(params INinjectModule[] modules)
        {
            _kernel = new StandardKernel(modules);
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if(controllerType==null)
            {
                throw new HttpException(404, String.Format("The controller for path '{0}' cound not be fount", requestContext.HttpContext.Request.Path));
            }
            return (IController)_kernel.Get(controllerType);
        }
    }
}
